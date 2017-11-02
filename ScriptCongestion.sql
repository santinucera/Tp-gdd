use GD2C2017

GO
create table CONGESTION.Funcionalidad(
	func_id int identity PRIMARY KEY,
	func_descripcion char(100) NULL
)

create table CONGESTION.Rol(
	rol_id int identity PRIMARY KEY,
	rol_descripcion char(100) NULL,
	rol_habilitado bit DEFAULT 1 NOT NULL
)

create table CONGESTION.Funcionalidad_Rol(
	fr_funcionalidad int FOREIGN KEY references CONGESTION.Funcionalidad(func_id),
	fr_rol int FOREIGN KEY references CONGESTION.Rol(rol_id)
)

create table CONGESTION.Usuario(
	usua_id int identity PRIMARY KEY,
	usua_username VARCHAR(64) NOT NULL,
	usua_password CHAR(64) NOT NULL,
	usua_habilitado bit DEFAULT 1 NOT NULL,
	usua_cantIntentos int DEFAULT 0 NOT NULL
)

create table CONGESTION.Rol_Usuario(
	ru_rol int FOREIGN KEY references CONGESTION.Rol(rol_id),
	ru_usuario int FOREIGN KEY references CONGESTION.Usuario(usua_id)
)

create table CONGESTION.Sucursal(
	suc_id int IDENTITY PRIMARY KEY,
	suc_nombre NVARCHAR(50) NOT NULL,
	suc_direccion nvarchar(50) NOT NULL,
	suc_codPostal numeric(18,0) unique NOT NULL,
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
	empr_habilitado bit DEFAULT 1 NOT NULL,
	empr_dia_rendicion int DEFAULT 1 NOT NULL
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
	rend_comision numeric(18,2) ,
	rend_total numeric(18,2) NOT NULL,
	rend_porcentaje_comision numeric(5,2) 
)

create table CONGESTION.Factura(
	fact_num int PRIMARY KEY,
	fact_cliente int FOREIGN KEY references CONGESTION.Cliente(clie_id) NOT NULL,
	fact_empresa int FOREIGN KEY references CONGESTION.Empresa(empr_id) NOT NULL,
	fact_rendicion int FOREIGN KEY references CONGESTION.Rendicion(rend_numero),
	fact_fecha_alta datetime NOT NULL,
	fact_fecha_venc datetime NOT NULL,
	fact_total numeric(18,2) NOT NULL
)

create table CONGESTION.Item_Factura(
	item_id int identity PRIMARY KEY,
	item_fact int FOREIGN KEY references CONGESTION.Factura(fact_num),
	item_monto numeric(18,2) NOT NULL,
	item_cantidad numeric(18,0) NOT NULL,
	item_concepto char(50) 
)

create table CONGESTION.Medio_Pago(
	med_id int identity PRIMARY KEY,
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

create table CONGESTION.Devolucion(
	devo_id int identity PRIMARY KEY,
	devo_fecha datetime NOT NULL,
	devo_motivo nvarchar(255) NOT NULL
)

create table CONGESTION.Factura_Registro(
	freg_factura int FOREIGN KEY references CONGESTION.Factura(fact_num),
	freg_registro int FOREIGN KEY references CONGESTION.Registro(reg_id),
	freg_devolucion int FOREIGN KEY references CONGESTION.Devolucion(devo_id)
)



----------/CREACION DE TABLAS


----------CREACION DE OBJETOS DE BASE DE DATOS

INSERT INTO CONGESTION.Sucursal(suc_nombre, suc_direccion, suc_codPostal)
	SELECT DISTINCT Sucursal_Nombre, Sucursal_Dirección, Sucursal_Codigo_Postal
	FROM gd_esquema.Maestra
	WHERE Sucursal_Codigo_Postal IS NOT NULL
	
INSERT INTO CONGESTION.Cliente (clie_nombre, clie_apellido, clie_dni, clie_direccion, clie_mail, clie_codPostal, clie_fecNac)
	SELECT DISTINCT [Cliente-Nombre], [Cliente-Apellido], [Cliente-Dni], [Cliente_Direccion], [Cliente_Mail], Cliente_Codigo_Postal, [Cliente-Fecha_Nac]
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

INSERT INTO CONGESTION.Rendicion(rend_numero,rend_fecha,rend_total,rend_cantidad_facturas,rend_comision,rend_porcentaje_comision)
	SELECT DISTINCT Rendicion_Nro,Rendicion_Fecha, sum(Factura_Total),count(Pago_nro), ItemRendicion_Importe,(ItemRendicion_Importe/sum(Factura_Total))*100
	FROM gd_esquema.Maestra
	WHERE Rendicion_Nro is not null
	GROUP BY Rendicion_Nro,Rendicion_Fecha,Factura_Total,Pago_nro,ItemRendicion_Importe


INSERT INTO CONGESTION.Factura(fact_num,fact_cliente,fact_empresa,fact_rendicion,fact_fecha_alta,fact_fecha_venc,fact_total)
	SELECT	Nro_Factura, 
			(SELECT DISTINCT clie_id 
				FROM CONGESTION.Cliente 
				WHERE clie_dni = m.[Cliente-Dni]),
			(SELECT DISTINCT empr_id 
				FROM CONGESTION.Empresa 
				WHERE empr_cuit = m.Empresa_Cuit),
			(SELECT TOP 1 aux.Rendicion_Nro
				FROM gd_esquema.Maestra aux
				WHERE aux.Nro_Factura = m.Nro_Factura
				GROUP BY Rendicion_Nro
				ORDER BY Rendicion_Nro DESC),
			Factura_Fecha,
			Factura_Fecha_Vencimiento,
			Factura_Total
	FROM gd_esquema.Maestra m
	GROUP BY Nro_Factura,m.[Cliente-Dni],m.Empresa_Cuit,Factura_Fecha,Factura_Fecha_Vencimiento,Factura_Total
	ORDER BY Nro_Factura ASC


INSERT INTO CONGESTION.Registro(reg_id,reg_cliente,reg_fecha_cobro,reg_medio_pago,reg_sucursal,reg_total)
	SELECT DISTINCT Pago_nro,
	(SELECT DISTINCT clie_id FROM CONGESTION.Cliente WHERE clie_dni= [Cliente-Dni]),
	Pago_Fecha,
	(SELECT DISTINCT med_id FROM CONGESTION.Medio_Pago WHERE med_descripcion = FormaPagoDescripcion),
	(SELECT DISTINCT suc_id FROM CONGESTION.Sucursal WHERE suc_codPostal= Sucursal_Codigo_Postal),
	Total
	FROM gd_esquema.Maestra
	WHERE Pago_nro is not null
	GROUP BY Pago_nro,[Cliente-Dni],Pago_Fecha,FormaPagoDescripcion,Sucursal_Codigo_Postal,Total

INSERT INTO CONGESTION.Item_Factura(item_fact,item_monto,item_cantidad)
	SELECT DISTINCT Nro_Factura,ItemFactura_Monto,ItemFactura_Cantidad
	FROM gd_esquema.Maestra

INSERT INTO CONGESTION.Factura_Registro(freg_factura,freg_registro)
	SELECT DISTINCT Nro_Factura,Pago_nro
	FROM gd_esquema.Maestra
	WHERE Pago_nro is not null

INSERT INTO CONGESTION.Item_Factura(item_fact,item_monto,item_cantidad)
	SELECT DISTINCT Nro_Factura,ItemFactura_Monto,ItemFactura_Cantidad
	FROM gd_esquema.Maestra


INSERT INTO CONGESTION.Rol (rol_descripcion) VALUES ('Administrador');
INSERT INTO CONGESTION.Rol (rol_descripcion) VALUES ('Cobrador');

INSERT INTO CONGESTION.Funcionalidad (func_descripcion) VALUES ('ABM de Rol');
INSERT INTO CONGESTION.Funcionalidad (func_descripcion) VALUES ('Registro de Usuario');
INSERT INTO CONGESTION.Funcionalidad (func_descripcion) VALUES ('ABM de Cliente');
INSERT INTO CONGESTION.Funcionalidad (func_descripcion) VALUES ('ABM de Empresa');
INSERT INTO CONGESTION.Funcionalidad (func_descripcion) VALUES ('ABM de Sucursal');
INSERT INTO CONGESTION.Funcionalidad (func_descripcion) VALUES ('ABM de Facturas');
INSERT INTO CONGESTION.Funcionalidad (func_descripcion) VALUES ('Registro de Pago de Facturas');
INSERT INTO CONGESTION.Funcionalidad (func_descripcion) VALUES ('Rendicion de Facturas Cobradas');
INSERT INTO CONGESTION.Funcionalidad (func_descripcion) VALUES ('Listado Estadistico');

GO
CREATE FUNCTION CONGESTION.Hashear_Password
(@password CHAR(64))
RETURNS CHAR(64)
BEGIN
  RETURN CONVERT(CHAR(64), HASHBYTES('SHA2_256', @password), 2)  
END
GO

GO
CREATE PROCEDURE CONGESTION.sp_login(@usuario VARCHAR(64), @password CHAR(64))
AS
	BEGIN
		DECLARE @pass_encriptada CHAR(64), @id INT;
		SET @pass_encriptada = CONGESTION.Hashear_Password(@password);
		SELECT @id = usua_id FROM CONGESTION.Usuario
			WHERE usua_username = @usuario AND usua_password = @pass_encriptada;
		IF(@id IS NOT NULL) SELECT @id AS 'NRO';
		ELSE SELECT 0 AS 'NRO';
	END	

GO
-- Trigger para encriptar pass al registrar un nuevo usuario
CREATE TRIGGER CONGESTION.Encriptar_Password
ON CONGESTION.Usuario
INSTEAD OF INSERT
AS 
BEGIN    
	DECLARE @password VARCHAR(64)
	DECLARE @username VARCHAR(64)

	SELECT @username = usua_username, @password = usua_password FROM inserted

	INSERT INTO CONGESTION.Usuario (usua_username, usua_password) VALUES ( @username, CONGESTION.Hashear_Password(@password)) 
END 
GO

INSERT INTO CONGESTION.Usuario
	(usua_username, usua_password) VALUES ('admin', 'w23e')

INSERT INTO CONGESTION.Funcionalidad_Rol
	(fr_funcionalidad,fr_rol) 
	SELECT  func_id, (SELECT DISTINCT rol_id FROM CONGESTION.Rol WHERE rol_descripcion = 'Administrador')
	FROM CONGESTION.Funcionalidad 


INSERT INTO CONGESTION.Rol_Usuario
	(ru_rol, ru_usuario) VALUES(
	(SELECT DISTINCT rol_id FROM CONGESTION.Rol WHERE rol_descripcion = 'Administrador'),
	(SELECT DISTINCT usua_id FROM CONGESTION.Usuario WHERE usua_username = 'admin'))

INSERT INTO CONGESTION.Funcionalidad (func_descripcion) VALUES ('Devolucion Facturas');

INSERT INTO CONGESTION.Usuario
	(usua_username, usua_password) VALUES ('asd', 'asd')

INSERT INTO CONGESTION.Rol_Usuario
	(ru_rol, ru_usuario) VALUES(
	(SELECT DISTINCT rol_id FROM CONGESTION.Rol WHERE rol_descripcion = 'Cobrador'),
	(SELECT DISTINCT usua_id FROM CONGESTION.Usuario WHERE usua_username = 'asd'))

INSERT INTO CONGESTION.Funcionalidad_Rol
	(fr_funcionalidad,fr_rol) 
	SELECT  func_id, (SELECT DISTINCT rol_id FROM CONGESTION.Rol WHERE rol_descripcion = 'Cobrador')
	FROM CONGESTION.Funcionalidad 
	WHERE func_descripcion != 'ABM de Rol' and func_descripcion  !='Listado Estadistico'


GO
CREATE PROCEDURE CONGESTION.sp_guardarSucursal(@codigo numeric(18,0),@direccion NVARCHAR(50), @nombre NVARCHAR(50))
AS
	BEGIN TRANSACTION tr	

	BEGIN TRY

		INSERT INTO CONGESTION.Sucursal(suc_codPostal,suc_direccion,suc_nombre) 
		VALUES (@codigo,@direccion,@nombre)
		
		
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION tr
		DECLARE @mensaje VARCHAR(255) = ERROR_MESSAGE()
		RAISERROR(@mensaje,11,0)

		RETURN
	END CATCH

	COMMIT TRANSACTION tr
GO


CREATE PROCEDURE CONGESTION.sp_modificarSucursal(@codigo numeric(18,0),@codigoViejo numeric(18,0),@direccion NVARCHAR(50), @nombre NVARCHAR(50))
AS
	BEGIN TRANSACTION tr	

	BEGIN TRY

		UPDATE CONGESTION.Sucursal SET suc_codPostal=@codigo,suc_direccion=@direccion,suc_nombre=@nombre 
		where suc_codPostal = @codigoViejo
		
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION tr
		DECLARE @mensaje VARCHAR(255) = ERROR_MESSAGE()
		RAISERROR(@mensaje,11,0)

		RETURN
	END CATCH

	COMMIT TRANSACTION tr
GO

CREATE PROCEDURE CONGESTION.sp_modificarHabilitacionSucursal(@codigo numeric(18,0), @habilitacion bit)
AS
	BEGIN TRANSACTION tr	

	BEGIN TRY

		UPDATE CONGESTION.Sucursal SET suc_habilitado=@habilitacion where suc_codPostal = @codigo
		
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION tr
		DECLARE @mensaje VARCHAR(255) = ERROR_MESSAGE()
		RAISERROR(@mensaje,11,0)

		RETURN
	END CATCH

	COMMIT TRANSACTION tr
GO

CREATE PROCEDURE CONGESTION.sp_guardarEmpresa(@cuit NVARCHAR(50),@direccion NVARCHAR(255), @nombre NVARCHAR(255), @descripcionRubro VARCHAR(255))
AS
	BEGIN TRANSACTION tr	--abro transaccion, asi guarda una empresa, y su vinculo con el rubro

	BEGIN TRY
		INSERT INTO CONGESTION.Empresa (empr_cuit,empr_direccion,empr_nombre) 
			VALUES (@cuit,@direccion,@nombre)	--tiene un trigger que lanza una excepcion

		INSERT INTO CONGESTION.Empresa_Rubro (er_empresa,er_rubro) 
			VALUES ((SELECT TOP 1 empr_id
						FROM CONGESTION.Empresa
						WHERE Empresa.empr_cuit = @cuit
					),
					(SELECT TOP 1 rub_id
						FROM CONGESTION.Rubro
						WHERE Rubro.rub_descripcion = @descripcionRubro
					)
				   )
		IF @@ROWCOUNT = 0
			BEGIN
				RAISERROR('Error al vincular la empresa con el rubro',11,0)	--verifico que haya guardado el registro, sino lanza error
			END
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION tr
		DECLARE @mensaje VARCHAR(255) = ERROR_MESSAGE()
		RAISERROR(@mensaje,11,0)

		RETURN
	END CATCH

	COMMIT TRANSACTION tr
GO

CREATE PROCEDURE CONGESTION.sp_modificarEmpresa(@cuitViejo NVARCHAR(50), @cuit NVARCHAR(50),@direccion NVARCHAR(255), @nombre NVARCHAR(255), @descripcionRubro VARCHAR(255))
AS
	BEGIN TRANSACTION tr	--abro transaccion, asi modifica una empresa, y su vinculo con el rubro

	BEGIN TRY

		IF (@cuit IN	(SELECT empr_cuit FROM CONGESTION.Empresa) and @cuit <> @cuitViejo)
		BEGIN
			RAISERROR('Ya existe una empresa con el mismo cuit',11,0)
		END

		UPDATE CONGESTION.Empresa
			SET empr_cuit = @cuit, empr_direccion = @direccion, empr_nombre = @nombre
			WHERE (empr_cuit = @cuitViejo)	--tiene un trigger que lanza una excepcion

		UPDATE CONGESTION.Empresa_Rubro
			SET er_rubro = (SELECT TOP 1 rub_id
								FROM CONGESTION.Rubro
								WHERE Rubro.rub_descripcion = @descripcionRubro
							)
			WHERE er_empresa = (SELECT TOP 1 empr_id
									FROM CONGESTION.Empresa
									WHERE empr_cuit = @cuit
								)
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION tr
		DECLARE @mensaje VARCHAR(255) = ERROR_MESSAGE()
		RAISERROR(@mensaje,11,0)

		RETURN
	END CATCH

	COMMIT TRANSACTION tr
GO

CREATE PROCEDURE CONGESTION.sp_cambiarHabilitacionDe(@cuit NVARCHAR(50),@habilitacion BIT)
AS
	BEGIN TRANSACTION tr	--abro transaccion, asi modifica una empresa, y su vinculo con el rubro

	BEGIN TRY

		UPDATE CONGESTION.Empresa
			SET empr_habilitado = @habilitacion
			WHERE (empr_cuit = @cuit)	--tiene un trigger que lanza una excepcion

	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION tr
		DECLARE @mensaje VARCHAR(255) = ERROR_MESSAGE()
		RAISERROR(@mensaje,11,0)

		RETURN
	END CATCH

	COMMIT TRANSACTION tr
GO


----------CREACION DE TRIGGERS

CREATE TRIGGER CONGESTION.validar_unica_empresa
ON CONGESTION.Empresa
INSTEAD OF INSERT
AS 
BEGIN    
	DECLARE @cuit NVARCHAR(50)
	DECLARE @direccion NVARCHAR(255)
	DECLARE @nombre NVARCHAR(255)

	SELECT @cuit = empr_cuit, @direccion = empr_direccion, @nombre = empr_nombre FROM inserted

	IF @cuit IN	(SELECT empr_cuit FROM CONGESTION.Empresa)
	BEGIN
		RAISERROR('Ya existe una empresa con el mismo cuit',11,0)
	END

	INSERT INTO CONGESTION.Empresa (empr_cuit, empr_direccion, empr_nombre) VALUES (@cuit, @direccion, @nombre)
END 
GO


----------CREACION DE VISTAS

CREATE VIEW CONGESTION.listado_empresas
AS
	SELECT e.empr_id, e.empr_nombre, e.empr_direccion, e.empr_cuit, e.empr_habilitado, r.rub_descripcion
	FROM CONGESTION.Empresa e	JOIN CONGESTION.Empresa_Rubro er on (e.empr_id = er.er_empresa)
								JOIN CONGESTION.Rubro r on (er.er_rubro = r.rub_id)
GO

----------PROCEDURES ROL

CREATE PROCEDURE CONGESTION.sp_guardarFuncionalidadRol
@nombreFuncionalidad nvarchar(100),
@nombreRol nvarchar(100)
AS
BEGIN
DECLARE
@IdFuncionalidad int,
@IdRol int

SELECT @IdFuncionalidad =  func_id FROM CONGESTION.Funcionalidad WHERE func_descripcion = @nombreFuncionalidad
SELECT @IdRol = rol_id FROM CONGESTION.Rol WHERE rol_descripcion = @nombreRol

IF NOT (EXISTS (SELECT fr_funcionalidad FROM CONGESTION.Funcionalidad_Rol WHERE fr_funcionalidad = @IdFuncionalidad AND fr_rol = @IdRol))
BEGIN
 INSERT INTO CONGESTION.Funcionalidad_Rol(fr_funcionalidad,fr_rol) VALUES (@IdFuncionalidad, @IdRol)
 END
 END
 GO


CREATE PROCEDURE CONGESTION.sp_eliminarFuncionalidadRol
@nombreFuncionalidad nvarchar(100),
@nombreRol nvarchar(100)
AS
BEGIN
DECLARE
@IdFuncionalidad int,
@IdRol int

SELECT @IdFuncionalidad =  func_id FROM CONGESTION.Funcionalidad WHERE func_descripcion = @nombreFuncionalidad
SELECT @IdRol = rol_id FROM CONGESTION.Rol WHERE rol_descripcion = @nombreRol

 DELETE FROM CONGESTION.Funcionalidad_Rol WHERE  fr_funcionalidad = @IdFuncionalidad AND  fr_rol = @IdRol
 END
 GO

 CREATE PROCEDURE CONGESTION.sp_updatearRol
 @nombreRol nvarchar(100),
 @nombreRolNuevo nvarchar(100)
 AS
 BEGIN
 DECLARE
 @CantidadDeRoles int

 SELECT @CantidadDeRoles = count(*) FROM CONGESTION.Rol WHERE rol_descripcion = @nombreRolNuevo

 IF NOT(@CantidadDeRoles = 1)
 BEGIN
 UPDATE CONGESTION.Rol SET rol_descripcion = @nombreRolNuevo WHERE rol_descripcion = @nombreRol
 END
 END 
 GO

 CREATE PROCEDURE CONGESTION.sp_agregarRol
 @nombreRol nvarchar(100)
 AS
 BEGIN
 IF NOT(EXISTS (SELECT rol_descripcion FROM CONGESTION.Rol WHERE rol_descripcion = @nombreRol))
 BEGIN
 INSERT INTO CONGESTION.Rol(rol_descripcion,rol_habilitado) VALUES (@nombreRol,'1')
 END
 END
 GO

 CREATE TYPE [CONGESTION].listaFacturas AS TABLE(
	[numero] int,
	[total] int
 )
 GO

 GO
CREATE PROCEDURE CONGESTION.sp_RendirFacturas(@listaFacturas listaFacturas readonly,@comision int,@cuit NVARCHAR(50))
AS
	BEGIN TRANSACTION tr	

	BEGIN TRY

		DECLARE @CantidadDeFacturas int
		DECLARE @total int
		DECLARE @numeroFactura int
		DECLARE @rendicion int
		DECLARE @rendNumero int
		DECLARE @porcentaje numeric(18,2)
		
		DECLARE cursorFacturas CURSOR FOR
		SELECT numero FROM @listaFacturas

		SELECT @CantidadDeFacturas =  count(*) FROM @listaFacturas
		SELECT @total =  sum(total) FROM @listaFacturas
		SELECT @rendNumero =  (SELECT TOP 1 rend_numero from CONGESTION.Rendicion order by rend_numero DESC) +1
		set @porcentaje = (@comision * 100.00)/@total
		
		INSERT INTO CONGESTION.Rendicion(rend_numero,rend_comision,rend_cantidad_facturas,rend_fecha,rend_total,rend_porcentaje_comision) 
			VALUES (@rendNumero,@comision,@CantidadDeFacturas,GETDATE(),@total,@porcentaje)

		OPEN cursorFacturas
		FETCH cursorFacturas INTO @numeroFactura
		
		WHILE(@@FETCH_STATUS = 0)
		BEGIN
			UPDATE CONGESTION.Factura SET fact_rendicion = @rendNumero where fact_num = @numeroFactura
			
			FETCH cursorFacturas INTO @numeroFactura
		END

		CLOSE cursorFacturas
		DEALLOCATE cursorFacturas


		
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION tr
		DECLARE @mensaje VARCHAR(255) = ERROR_MESSAGE()
		RAISERROR(@mensaje,11,0)

		RETURN
	END CATCH

	COMMIT TRANSACTION tr
GO

CREATE TYPE [CONGESTION].listaItemsFactura AS TABLE(
	[monto] numeric(18,2),
	[cantidad] numeric(18,0),
	[concepto] char(50)
 )


GO
CREATE PROCEDURE CONGESTION.sp_ValidarModificacionFactura(@numero int)
AS
	if (exists(SELECT * from CONGESTION.Factura Where fact_num = @numero and fact_rendicion is not null )
			or exists(SELECT * from CONGESTION.Factura_Registro WHERE freg_factura =@numero))
		BEGIN
			RAISERROR('No se puede modificar una factura paga/rendida',11,0)
		END  
GO


CREATE PROCEDURE CONGESTION.sp_guardarFactura(@listaFacturas listaItemsFactura readonly,@numero int,@cuit NVARCHAR(50),@dni numeric(18,0),@fechaVen datetime)
AS
	BEGIN TRANSACTION tr	

	BEGIN TRY
		
		DECLARE @cliente int
		DECLARE @empresa int
		DECLARE @total numeric(18,2)
		DECLARE @monto numeric(18,2)
		DECLARE @cantidad numeric(18,0)
		DECLARE @concepto char(50)

		DECLARE cursorItems CURSOR FOR
		SELECT monto,cantidad,concepto FROM @listaFacturas

		SELECT @total =  sum(monto*cantidad) FROM @listaFacturas
		SELECT @cliente =   clie_id FROM CONGESTION.Cliente where clie_dni = @dni			
			
		if @cliente is null
		BEGIN
			RAISERROR('No existe cliente con ese dni',11,0)
		END
			
		SELECT @empresa = empr_id FROM CONGESTION.Empresa where empr_cuit = @cuit
		
		INSERT INTO CONGESTION.Factura(fact_num,fact_cliente,fact_empresa,fact_fecha_alta,fact_fecha_venc,fact_total) 
		VALUES (@numero,@cliente,@empresa,GETDATE(),@fechaVen,@total)



		OPEN cursorItems
		FETCH cursorItems INTO @monto,@cantidad,@concepto
		
		WHILE(@@FETCH_STATUS = 0)
		BEGIN
			INSERT INTO CONGESTION.Item_Factura(item_fact,item_monto,item_cantidad,item_concepto) 
			VALUES (@numero,@monto,@cantidad,@concepto)
		
			FETCH cursorItems INTO @monto,@cantidad,@concepto
		END

		CLOSE cursorItems
		DEALLOCATE cursorItems
				
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION tr
		DECLARE @mensaje VARCHAR(255) = ERROR_MESSAGE()
		RAISERROR(@mensaje,11,0)

		RETURN
	END CATCH

	COMMIT TRANSACTION tr
GO

CREATE PROCEDURE CONGESTION.sp_modificarFactura(@numero int,@dni numeric(18,0),@cuit NVARCHAR(50), @fechaVen datetime)
AS
	BEGIN TRANSACTION tr	

	BEGIN TRY

	DECLARE @cliente int
	DECLARE @empresa int

	SELECT @empresa = empr_id FROM CONGESTION.Empresa where empr_cuit = @cuit
	SELECT @cliente =   clie_id FROM CONGESTION.Cliente where clie_dni = @dni	
	
	if @cliente is null
		BEGIN
			RAISERROR('No existe cliente con ese dni',11,0)
		END

	EXEC CONGESTION.sp_ValidarModificacionFactura @numero

	UPDATE CONGESTION.Factura SET fact_cliente =@cliente,fact_empresa = @empresa,fact_fecha_venc=@fechaVen
        WHERE fact_num = @numero
		
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION tr
		DECLARE @mensaje VARCHAR(255) = ERROR_MESSAGE()
		RAISERROR(@mensaje,11,0)

		RETURN
	END CATCH

	COMMIT TRANSACTION tr
GO

CREATE PROCEDURE CONGESTION.sp_guardarItem(@numero int,@monto numeric(18,2),@cantidad numeric(18,0), @concepto char(50))
AS
	BEGIN TRANSACTION tr	

	BEGIN TRY

	EXEC CONGESTION.sp_ValidarModificacionFactura @numero 

	INSERT INTO CONGESTION.Item_Factura(item_fact,item_monto,item_cantidad,item_concepto) 
		VALUES (@numero,@monto,@cantidad,@concepto)
		
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION tr
		DECLARE @mensaje VARCHAR(255) = ERROR_MESSAGE()
		RAISERROR(@mensaje,11,0)

		RETURN
	END CATCH

	COMMIT TRANSACTION tr
GO

CREATE PROCEDURE CONGESTION.sp_modificarItem(@numero int,@monto numeric(18,2),@cantidad numeric(18,0), @concepto char(50))
AS
	BEGIN TRANSACTION tr	

	BEGIN TRY

	EXEC CONGESTION.sp_ValidarModificacionFactura @numero 

	UPDATE CONGESTION.Item_Factura SET item_monto = @monto, item_cantidad= @cantidad, item_concepto = @concepto where item_fact = @numero

	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION tr
		DECLARE @mensaje VARCHAR(255) = ERROR_MESSAGE()
		RAISERROR(@mensaje,11,0)

		RETURN
	END CATCH

	COMMIT TRANSACTION tr
GO

CREATE PROCEDURE CONGESTION.sp_eliminarItem(@id int,@numero int)
AS
	BEGIN TRANSACTION tr	

	BEGIN TRY

	EXEC CONGESTION.sp_ValidarModificacionFactura @numero

	DELETE FROM CONGESTION.Item_Factura where item_id = @id
		
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION tr
		DECLARE @mensaje VARCHAR(255) = ERROR_MESSAGE()
		RAISERROR(@mensaje,11,0)

		RETURN
	END CATCH

	COMMIT TRANSACTION tr
GO

CREATE PROCEDURE CONGESTION.sp_DevolverFactura(@factura int,@pago int,@motivo nvarchar(255))
AS
	BEGIN TRANSACTION tr	

	BEGIN TRY

	INSERT INTO CONGESTION.Devolucion (devo_motivo,devo_fecha)
	VALUES(@motivo,GETDATE())

	DECLARE @idDevo int

	SET @idDevo = SCOPE_IDENTITY()

	UPDATE CONGESTION.Factura_Registro SET freg_devolucion = @idDevo
	WHERE freg_factura = @factura and freg_registro = @pago
		
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION tr
		DECLARE @mensaje VARCHAR(255) = ERROR_MESSAGE()
		RAISERROR(@mensaje,11,0)

		RETURN
	END CATCH

	COMMIT TRANSACTION tr
GO

-- VIEW clientes con mas pagos
CREATE VIEW CONGESTION.clientesConMasPagos
AS
SELECT clie_nombre,reg_fecha_cobro 
FROM CONGESTION.Cliente JOIN CONGESTION.Registro ON clie_id = reg_cliente

SELECT TOP 5 clie_nombre,count(*) FROM CONGESTION.viewClientesConMasPagos GROUP BY clie_nombre ORDER BY 2 DESC
 -------------------

 -- VIEW empresas con mayor monto rendido
 CREATE VIEW CONGESTION.empresasConMayorMontoRendido
 AS
 SELECT  empr_nombre,rend_total,rend_fecha
 FROM CONGESTION.Empresa JOIN CONGESTION.Factura ON empr_id = fact_empresa JOIN CONGESTION.Rendicion ON fact_rendicion = rend_numero
----------