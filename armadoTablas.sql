use GD2C2017
use GD2C2017

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
	suc_habilitado bit NOT NULL
)

create table CONGESTION.Usuario_Sucursal(
	usuc_usuario int FOREIGN KEY references CONGESTION.Usuario(usua_id),
	usuc_sucursal int FOREIGN KEY references CONGESTION.Sucursal(suc_id)
)


create table CONGESTION.Rubro(
	rub_id int identity PRIMARY KEY,
	rub_descripcion char(100) NULL
)

create table CONGESTION.Empresa(
	empr_id int identity PRIMARY KEY,
	empr_cuit char(15) NOT NULL,
	empr_direccion char(30) NOT NULL,
	empr_nombre char(30) NOT NULL,
	empr_habilitado bit NOT NULL
)

create table CONGESTION.Empresa_Rubro(
	er_empresa int FOREIGN KEY references CONGESTION.Empresa(empr_id),
	er_rubro int FOREIGN KEY references CONGESTION.Rubro(rub_id)
)


create table CONGESTION.Cliente(
	clie_id int identity PRIMARY KEY,
	clie_nombre char(30) NOT NULL,
	clie_apellido char(30) NOT NULL,
	clie_dni char(9) NOT NULL,
	clie_direccion char(30) NULL,
	clie_telefono char(30) NULL,
	clie_mail char(30) NULL,
	clie_codPostal char(30) NULL,
	clie_fecNac smalldatetime NULL,
	clie_habilitado bit NOT NULL
)

create table CONGESTION.Factura(
	fact_num int PRIMARY KEY,
	fact_cliente int FOREIGN KEY references CONGESTION.Cliente(clie_id),
	fact_empresa int FOREIGN KEY references CONGESTION.Empresa(empr_id),
	fact_rendicion int NOT NULL,
	fact_dni char(9) NOT NULL,
	fact_fecha_alta smalldatetime NOT NULL,
	fact_fecha_venc smalldatetime NOT NULL,
	fact_total int NOT NULL
)

create table CONGESTION.Item_factura(
	item_id int identity PRIMARY KEY,
	item_fact int FOREIGN KEY references CONGESTION.Factura(fact_num),
	item_monto int NOT NULL,
	item_cantidad int NOT NULL,
	item_concepto char(50) NOT NULL
)

create table CONGESTION.Medio_Pago(
	med_id int PRIMARY KEY,
	med_descripcion char(50)
)

create table CONGESTION.Registro(
	reg_id int identity PRIMARY KEY,
	reg_fact int FOREIGN KEY references CONGESTION.Factura(fact_num),
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


create table CONGESTION.Rendicion(
	rend_id int identity PRIMARY KEY,
	rend_empresa int FOREIGN KEY references CONGESTION.Factura(fact_num) NOT NULL,
	rend_fecha smallint NOT NULL,
	rend_cantidad_facturas int NOT NULL,
	rend_comision int NOT NULL,
	rend_total int NOT NULL,
	rend_porcentaje_comision numeric(5,2) NOT NULL
)

create table CONGESTION.Devolucion(
	devo_id int identity PRIMARY KEY,
	devo_rendicion int FOREIGN KEY references CONGESTION.Rendicion(rend_id) NULL,
	devo_registro int FOREIGN KEY references CONGESTION.Registro(reg_id) NULL,
	devo_fecha smallint NOT NULL,
	devo_motivo char(50) NOT NULL
)

alter table CONGESTION.Factura
add constraint FK_fact_rendicion FOREIGN KEY (fact_rendicion) references CONGESTION.Rendicion(rend_id)