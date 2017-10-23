use GD2C2017

GO
create table CONGESTION.Funcionalidad(
	func_id int identity PRIMARY KEY,
	func_descripcion char(100) NULL
)

create table CONGESTION.Rol(
	rol_id int identity PRIMARY KEY,
	rol_descripcion char(100) NULL,
	rol_habilitado bit NOT NULL
)

create table CONGESTION.Funcionalidad_Rol(
	fr_funcionalidad int FOREIGN KEY references CONGESTION.Funcionalidad(func_id),
	fr_rol int FOREIGN KEY references CONGESTION.Rol(rol_id)
)

create table CONGESTION.Usuario(
	usua_id int identity PRIMARY KEY,
	usua_username char(30) NOT NULL,
	usua_password char(30) NOT NULL,
	usua_habilitado bit NOT NULL
)

create table CONGESTION.Rol_Usuario(
	ru_rol int FOREIGN KEY references CONGESTION.Rol(rol_id),
	ru_usuario int FOREIGN KEY references CONGESTION.Usuario(usua_id)
)

create table CONGESTION.Sucursal(
	suc_id int identity PRIMARY KEY,
	suc_nombre char(30) NOT NULL,
	suc_direccion char(30) NOT NULL,
	suc_codPostal char(4) NOT NULL,
	suc_habilitado bit DEFAULT 1 NOT NULL
)

create table CONGESTION.Usuario_Sucursal(
	usuc_usuario int FOREIGN KEY references CONGESTION.Usuario(usua_id),
	usuc_sucursal int FOREIGN KEY references CONGESTION.Sucursal(suc_id)
)


create table CONGESTION.Rubro(
	rub_id int PRIMARY KEY,
	rub_descripcion nvarchar(50) NULL
)

create table CONGESTION.Empresa(
	empr_id int identity PRIMARY KEY,
	empr_cuit nvarchar(50) NOT NULL,
	empr_direccion nvarchar(255)  NOT NULL,
	empr_nombre nvarchar(255)  NOT NULL,
	empr_habilitado bit DEFAULT 1 NOT NULL
)

create table CONGESTION.Empresa_Rubro(
	er_empresa int FOREIGN KEY references CONGESTION.Empresa(empr_id),
	er_rubro int FOREIGN KEY references CONGESTION.Rubro(rub_id)
)


create table CONGESTION.Cliente(
	clie_id int identity PRIMARY KEY,
	clie_nombre nvarchar(255) NOT NULL,
	clie_apellido nvarchar(255) NOT NULL,
	clie_dni numeric(18,0) NOT NULL,
	clie_direccion nvarchar(255) NULL,
	clie_telefono char(30) NULL,
	clie_mail nvarchar(255) NULL,
	clie_codPostal nvarchar(255) NULL,
	clie_fecNac datetime NULL,
	clie_habilitado bit DEFAULT 1 NOT NULL
)

create table CONGESTION.Rendicion(
	rend_numero int PRIMARY KEY,
	rend_fecha datetime NOT NULL,
	rend_cantidad_facturas int ,
	rend_comision int ,
	rend_total int NOT NULL,
	rend_porcentaje_comision numeric(5,2) 
)

create table CONGESTION.Factura(
	fact_num int PRIMARY KEY,
	fact_cliente int FOREIGN KEY references CONGESTION.Cliente(clie_id),
	fact_empresa int FOREIGN KEY references CONGESTION.Empresa(empr_id),
	fact_rendicion int FOREIGN KEY references CONGESTION.Rendicion(rend_numero),
	fact_fecha_alta smalldatetime NOT NULL,
	fact_fecha_venc smalldatetime NOT NULL,
	fact_total int NOT NULL
)

create table CONGESTION.Item_Factura(
	item_id int identity(1,1) PRIMARY KEY,
	item_fact int FOREIGN KEY references CONGESTION.Factura(fact_num),
	item_monto numeric(18,2) NOT NULL,
	item_cantidad numeric(18,0) NOT NULL,
	item_concepto char(50) 
)

create table CONGESTION.Medio_Pago(
	med_id int identity(1,1) PRIMARY KEY,
	med_descripcion nvarchar(255)
)

create table CONGESTION.Registro(
	reg_id int PRIMARY KEY,
	reg_cliente int FOREIGN KEY references CONGESTION.Cliente(clie_id),
	reg_sucursal int FOREIGN KEY references CONGESTION.Sucursal(suc_id),
	reg_medio_pago int FOREIGN KEY references CONGESTION.Medio_Pago(med_id),
	reg_fecha_cobro smalldatetime NOT NULL,
	reg_total int NOT NULL
)

create table CONGESTION.Factura_Registro(
	freg_factura int FOREIGN KEY references CONGESTION.Factura(fact_num),
	freg_registro int FOREIGN KEY references CONGESTION.Registro(reg_id),
)


create table CONGESTION.Devolucion(
	devo_id int identity PRIMARY KEY,
	devo_rendicion int FOREIGN KEY references CONGESTION.Rendicion(rend_numero) NULL,
	devo_registro int FOREIGN KEY references CONGESTION.Registro(reg_id) NULL,
	devo_fecha smallint NOT NULL,
	devo_motivo char(50) NOT NULL
)


----------/CREACION DE TABLAS


----------CREACION DE OBJETOS DE BASE DE DATOS

INSERT INTO CONGESTION.Sucursal(suc_nombre, suc_direccion, suc_codPostal)
	SELECT DISTINCT Sucursal_Nombre, Sucursal_Direcci�n, Sucursal_Codigo_Postal
	FROM gd_esquema.Maestra
	WHERE Sucursal_Nombre IS NOT NULL and Sucursal_Direcci�n IS NOT NULL and Sucursal_Codigo_Postal IS NOT NULL
	
INSERT INTO CONGESTION.Cliente (clie_nombre, clie_apellido, clie_dni, clie_direccion, clie_telefono, clie_mail, clie_codPostal, clie_fecNac)
	SELECT DISTINCT [Cliente-Nombre], [Cliente-Apellido], [Cliente-Dni], [Cliente_Direccion], NULL, [Cliente_Mail], Cliente_Codigo_Postal, [Cliente-Fecha_Nac]
	FROM gd_esquema.Maestra
	
INSERT INTO CONGESTION.Rubro (rub_id,rub_descripcion)
	SELECT DISTINCT Empresa_Rubro,Rubro_Descripcion
	FROM gd_esquema.Maestra
	
INSERT INTO CONGESTION.Empresa(empr_cuit,empr_direccion,empr_nombre)
	SELECT DISTINCT Empresa_Cuit,Empresa_Direccion,Empresa_Nombre
	FROM gd_esquema.Maestra

INSERT INTO CONGESTION.Medio_Pago(med_descripcion)
	SELECT DISTINCT FormaPagoDescripcion
	FROM gd_esquema.Maestra
	
INSERT INTO CONGESTION.Empresa_Rubro(er_rubro,er_empresa)
	SELECT DISTINCT Empresa_Rubro, (SELECT DISTINCT  empr_id FROM CONGESTION.Empresa WHERE empr_cuit= [Empresa_Cuit])
	FROM gd_esquema.Maestra
	GROUP BY Empresa_Rubro, [Empresa_Cuit]

INSERT INTO CONGESTION.Rendicion(rend_numero,rend_fecha,rend_total)
	SELECT DISTINCT Rendicion_Nro,Rendicion_Fecha, sum(ItemRendicion_Importe) 
	FROM gd_esquema.Maestra
	WHERE Rendicion_Nro is not null
	GROUP BY Rendicion_Nro,Rendicion_Fecha


GO
CREATE PROCEDURE CONGESTION.Migrar_Facturas
AS
BEGIN 
	print 'facturas'
	 DECLARE facturas CURSOR FOR 
	 SELECT DISTINCT Nro_Factura,Factura_Fecha,Factura_Fecha_Vencimiento,Factura_Total,[Cliente-Dni],Empresa_Cuit,Rendicion_Nro
	 FROM gd_esquema.Maestra
	      	 
	 DECLARE @numero numeric(18,0);
	 DECLARE @fecha datetime;
	 DECLARE @fecha_venc datetime;
	 DECLARE @total numeric(18,2);
	 DECLARE @dni numeric(18,0);
	 DECLARE @cuit nvarchar(50);
	 DECLARE @rendicion numeric(18,0);
	 DECLARE @cliente int;
	 DECLARE @empresa int;
	 
	 OPEN facturas;
	 FETCH NEXT FROM facturas INTO @numero,@fecha,@fecha_venc,@total,@dni,@cuit,@rendicion;
	 
	 WHILE (@@FETCH_STATUS = 0)
		BEGIN	

			SELECT @cliente = (SELECT DISTINCT clie_id FROM CONGESTION.Cliente WHERE clie_dni = @dni);
			SELECT @empresa = (SELECT DISTINCT empr_id FROM CONGESTION.Empresa WHERE empr_cuit = @cuit);

			if exists (Select fact_num from CONGESTION.Factura WHERE fact_num= @numero group by fact_num)
			begin
				DELETE FROM CONGESTION.Factura WHERE fact_num = @numero;
			end
			

			INSERT INTO CONGESTION.Factura(fact_num,fact_cliente,fact_empresa,fact_rendicion,fact_fecha_alta,fact_fecha_venc,fact_total)
				VALUES (@numero,@cliente,@empresa,@rendicion,@fecha,@fecha_venc,@total);
			
			FETCH NEXT FROM facturas INTO @numero,@fecha,@fecha_venc,@total,@dni,@cuit,@rendicion;
		END 

	 CLOSE facturas;
	 DEALLOCATE facturas;
END
GO

EXEC CONGESTION.Migrar_Facturas;


INSERT INTO CONGESTION.Registro(reg_id,reg_cliente,reg_fecha_cobro,reg_medio_pago,reg_sucursal,reg_total)
	SELECT DISTINCT Pago_nro,
	(SELECT DISTINCT clie_id FROM CONGESTION.Cliente WHERE clie_dni= [Cliente-Dni]),
	Pago_Fecha,
	(SELECT DISTINCT med_id FROM CONGESTION.Medio_Pago WHERE med_descripcion = FormaPagoDescripcion),
	(SELECT DISTINCT suc_id FROM CONGESTION.Sucursal WHERE suc_codPostal= Sucursal_Codigo_Postal),
	Total
	FROM gd_esquema.Maestra
	GROUP BY Pago_nro,[Cliente-Dni],Pago_Fecha,FormaPagoDescripcion,Sucursal_Codigo_Postal,Total

INSERT INTO CONGESTION.Item_Factura(item_fact,item_monto,item_cantidad)
	SELECT DISTINCT Nro_Factura,ItemFactura_Monto,ItemFactura_Cantidad
	FROM gd_esquema.Maestra

INSERT INTO CONGESTION.Factura_Registro(freg_factura,freg_registro)
	SELECT DISTINCT Nro_Factura,Pago_nro
	FROM gd_esquema.Maestra

INSERT INTO CONGESTION.Item_Factura(item_fact,item_monto,item_cantidad)
	SELECT DISTINCT Nro_Factura,ItemFactura_Monto,ItemFactura_Cantidad
	FROM gd_esquema.Maestra



