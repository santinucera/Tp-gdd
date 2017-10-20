USE [GD2C2017]

CREATE TABLE [gd_esquema].[Cliente](
	[clie_id] [numeric](6, 0) IDENTITY (1,1) NOT NULL,
	[clie_dni] [numeric](8, 0) NOT NULL,
	[clie_apellido] [char](50) NULL,
	[clie_nombre] [char](50) NULL,
	[clie_fecha_nac] [date] NULL,
	[clie_mail] [char](50) NOT NULL,
	[clie_direccion] [char](100) NULL,
	[clie_codigo_postal] [char](20) NULL,
	[clie_habilitado] [bit] DEFAULT 1 NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[clie_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[Devolucion](
	[devo_id] [numeric](6, 0) NOT NULL,
	[devo_pago_factura] [numeric](6, 0) NOT NULL,
	[devo_motivo] [char](100) NULL,
	[devo_fecha] [date] NOT NULL,
 CONSTRAINT [PK_Devolucion] PRIMARY KEY CLUSTERED 
(
	[devo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[Empresa](
	[empr_id] [numeric](6, 0) NOT NULL,
	[empr_nombre] [char](50) NULL,
	[empr_cuit] [numeric](11, 0) NULL,
	[empr_direccion] [char](100) NULL,
	[empr_habilitado] [bit] NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[empr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[Factura](
	[fact_numero] [numeric](6, 0) NOT NULL,
	[fact_fecha_alta] [date] NOT NULL,
	[fact_fecha_vencimiento] [date] NOT NULL,
	[fact_cliente] [numeric](6, 0) NOT NULL,
	[fact_empresa] [numeric](6, 0) NOT NULL,
	[fact_cobrada] [bit] NULL,
	[fact_rendicion] [numeric](6, 0) NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[fact_numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[Funcionalidad](
	[fund_id] [numeric](6, 0) NOT NULL,
	[fund_descripcion] [char](100) NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[fund_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[FuncionalidadRol](
	[func_rol_rol] [numeric](6, 0) NOT NULL,
	[func_rol_funcionalidad] [numeric](6, 0) NOT NULL,
 CONSTRAINT [PK_FuncionalidadRol] PRIMARY KEY CLUSTERED 
(
	[func_rol_rol] ASC,
	[func_rol_funcionalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[ItemFactura](
	[item_fact_monto] [decimal](12, 2) NULL,
	[item_fact_cantidad] [decimal](12, 2) NULL,
	[item_fact_factura] [numeric](6, 0) NULL,
	[item_fact_concepto] [char](100) NULL,
	[item_fact_id] [numeric](6, 0) NOT NULL,
 CONSTRAINT [PK_ItemFactura] PRIMARY KEY CLUSTERED 
(
	[item_fact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[MedioPago](
	[medio_pago_id] [numeric](6, 0) NOT NULL,
	[medio_pago_descripcion] [char](50) NOT NULL,
 CONSTRAINT [PK_MedioPago] PRIMARY KEY CLUSTERED 
(
	[medio_pago_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[Registro](
	[regi_numero] [numeric](6, 0) NOT NULL,
	[regi_fecha] [date] NOT NULL,
	[regi_medio_pago] [numeric](6, 0) NOT NULL,
	[regi_sucursal] [numeric](6, 0) NOT NULL,
	[regi_usuario] [numeric](6, 0) NOT NULL,
 CONSTRAINT [PK_Registro] PRIMARY KEY CLUSTERED 
(
	[regi_numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[RegistroFactura](
	[regi_fact_registro] [numeric](6, 0) NOT NULL,
	[regi_fact_factura] [numeric](6, 0) NOT NULL,
	[regi_fact_anulado] [bit] NULL,
 CONSTRAINT [PK_Rubro.Empresa] PRIMARY KEY CLUSTERED 
(
	[regi_fact_registro] ASC,
	[regi_fact_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[Rendicion](
	[rend_numero] [numeric](6, 0) NOT NULL,
	[rend_fecha] [date] NOT NULL,
	[rend_total] [decimal](12, 2) NOT NULL,
	[rend_coef_comision] [float] NOT NULL,
	[rend_concepto] [char](100) NOT NULL,
	[rend_empresa] [numeric](6, 0) NOT NULL,
 CONSTRAINT [PK_Rendicion] PRIMARY KEY CLUSTERED 
(
	[rend_numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[Rol](
	[rol_id] [numeric](6, 0) NOT NULL,
	[rol_nombre] [char](50) NULL,
	[rol_habilitado] [bit] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[Rubro](
	[rubr_id] [numeric](6, 0) NOT NULL,
	[rubr_detalle] [char](100) NULL,
 CONSTRAINT [PK_Rubro] PRIMARY KEY CLUSTERED 
(
	[rubr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[RubroEmpresa](
	[empr_id] [numeric](6, 0) NOT NULL,
	[rubr_id] [numeric](6, 0) NOT NULL,
 CONSTRAINT [PK_Rubro.Empresa] PRIMARY KEY CLUSTERED 
(
	[empr_id] ASC,
	[rubr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[Sucursal](
	[sucu_id] [numeric](6, 0) IDENTITY (1,1) NOT NULL,
	[sucu_nombre] [nvarchar](50) NULL,
	[sucu_direccion] [nvarchar](50) NULL,
	[sucu_codigo_postal] [numeric](18,0) NULL,
	[sucu_habilitado] [bit] DEFAULT 1 NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[sucu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[Usuario](
	[user_id] [numeric](6, 0) NOT NULL,
	[user_nombre] [char](50) NULL,
	[user_habilitado] [bit] NULL,
	[user_password] [char](30) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[UsuarioRol](
	[user_rol_usuario] [numeric](6, 0) NOT NULL,
	[user_rol_rol] [numeric](6, 0) NOT NULL,
 CONSTRAINT [PK_UsuarioRol] PRIMARY KEY CLUSTERED 
(
	[user_rol_usuario] ASC,
	[user_rol_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[UsuarioSucursal](
	[user_suc_usuario] [numeric](6, 0) NOT NULL,
	[user_suc_sucursal] [numeric](6, 0) NOT NULL,
 CONSTRAINT [PK_UsuarioSucursal] PRIMARY KEY CLUSTERED 
(
	[user_suc_usuario] ASC,
	[user_suc_sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [gd_esquema].[Devolucion]  WITH CHECK ADD  CONSTRAINT [FK_DevoPagoFact] FOREIGN KEY([devo_pago_factura])
REFERENCES [gd_esquema].[RegistroFactura] ([regi_fact_numero])
GO
ALTER TABLE [gd_esquema].[Devolucion] CHECK CONSTRAINT [FK_DevoPagoFact]
GO
ALTER TABLE [gd_esquema].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_FactClien] FOREIGN KEY([fact_cliente])
REFERENCES [gd_esquema].[Cliente] ([clie_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [gd_esquema].[Factura] CHECK CONSTRAINT [FK_FactClien]
GO
ALTER TABLE [gd_esquema].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_FactEmpr] FOREIGN KEY([fact_empresa])
REFERENCES [gd_esquema].[Empresa] ([empr_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [gd_esquema].[Factura] CHECK CONSTRAINT [FK_FactEmpr]
GO
ALTER TABLE [gd_esquema].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_FactRend] FOREIGN KEY([fact_numero])
REFERENCES [gd_esquema].[Rendicion] ([rend_numero])
GO
ALTER TABLE [gd_esquema].[Factura] CHECK CONSTRAINT [FK_FactRend]
GO
ALTER TABLE [gd_esquema].[FuncionalidadRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncRolFunc] FOREIGN KEY([func_rol_funcionalidad])
REFERENCES [gd_esquema].[Funcionalidad] ([fund_id])
GO
ALTER TABLE [gd_esquema].[FuncionalidadRol] CHECK CONSTRAINT [FK_FuncRolFunc]
GO
ALTER TABLE [gd_esquema].[FuncionalidadRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncRolRol] FOREIGN KEY([func_rol_rol])
REFERENCES [gd_esquema].[Rol] ([rol_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [gd_esquema].[FuncionalidadRol] CHECK CONSTRAINT [FK_FuncRolRol]
GO
ALTER TABLE [gd_esquema].[ItemFactura]  WITH CHECK ADD  CONSTRAINT [FK_ItemFactFact] FOREIGN KEY([item_fact_factura])
REFERENCES [gd_esquema].[Factura] ([fact_numero])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [gd_esquema].[ItemFactura] CHECK CONSTRAINT [FK_ItemFactFact]
GO
ALTER TABLE [gd_esquema].[Registro]  WITH CHECK ADD  CONSTRAINT [FK_PagoMedio] FOREIGN KEY([regi_medio_pago])
REFERENCES [gd_esquema].[MedioPago] ([medio_pago_id])
GO
ALTER TABLE [gd_esquema].[Registro] CHECK CONSTRAINT [FK_PagoMedio]
GO
ALTER TABLE [gd_esquema].[Registro]  WITH CHECK ADD  CONSTRAINT [FK_PagoSucu] FOREIGN KEY([regi_sucursal])
REFERENCES [gd_esquema].[Sucursal] ([sucu_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [gd_esquema].[Registro] CHECK CONSTRAINT [FK_PagoSucu]
GO
ALTER TABLE [gd_esquema].[Registro]  WITH CHECK ADD  CONSTRAINT [FK_PagoUser] FOREIGN KEY([regi_usuario])
REFERENCES [gd_esquema].[Usuario] ([user_id])
GO
ALTER TABLE [gd_esquema].[Registro] CHECK CONSTRAINT [FK_PagoUser]
GO
ALTER TABLE [gd_esquema].[RegistroFactura]  WITH CHECK ADD  CONSTRAINT [FK_PagoFactFact] FOREIGN KEY([regi_fact_factura])
REFERENCES [gd_esquema].[Factura] ([fact_numero])
GO
ALTER TABLE [gd_esquema].[RegistroFactura] CHECK CONSTRAINT [FK_PagoFactFact]
GO
ALTER TABLE [gd_esquema].[RegistroFactura]  WITH CHECK ADD  CONSTRAINT [FK_PagoFactPago] FOREIGN KEY([regi_fact_registro])
REFERENCES [gd_esquema].[Registro] ([regi_numero])
GO
ALTER TABLE [gd_esquema].[RegistroFactura] CHECK CONSTRAINT [FK_PagoFactPago]
GO
ALTER TABLE [gd_esquema].[Rendicion]  WITH CHECK ADD  CONSTRAINT [FK_RendEmpr] FOREIGN KEY([rend_empresa])
REFERENCES [gd_esquema].[Empresa] ([empr_id])
GO
ALTER TABLE [gd_esquema].[Rendicion] CHECK CONSTRAINT [FK_RendEmpr]
GO
ALTER TABLE [gd_esquema].[RubroEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_RubrEmprEmpr] FOREIGN KEY([empr_id])
REFERENCES [gd_esquema].[Empresa] ([empr_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [gd_esquema].[RubroEmpresa] CHECK CONSTRAINT [FK_RubrEmprEmpr]
GO
ALTER TABLE [gd_esquema].[RubroEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_RubrEmprRubr] FOREIGN KEY([rubr_id])
REFERENCES [gd_esquema].[Rubro] ([rubr_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [gd_esquema].[RubroEmpresa] CHECK CONSTRAINT [FK_RubrEmprRubr]
GO
ALTER TABLE [gd_esquema].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_UserRolRol] FOREIGN KEY([user_rol_rol])
REFERENCES [gd_esquema].[Rol] ([rol_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [gd_esquema].[UsuarioRol] CHECK CONSTRAINT [FK_UserRolRol]
GO
ALTER TABLE [gd_esquema].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_UserRolUser] FOREIGN KEY([user_rol_usuario])
REFERENCES [gd_esquema].[Usuario] ([user_id])
GO
ALTER TABLE [gd_esquema].[UsuarioRol] CHECK CONSTRAINT [FK_UserRolUser]
GO
ALTER TABLE [gd_esquema].[UsuarioSucursal]  WITH CHECK ADD  CONSTRAINT [FK_UserSucSuc] FOREIGN KEY([user_suc_sucursal])
REFERENCES [gd_esquema].[Sucursal] ([sucu_id])
GO
ALTER TABLE [gd_esquema].[UsuarioSucursal] CHECK CONSTRAINT [FK_UserSucSuc]
GO
ALTER TABLE [gd_esquema].[UsuarioSucursal]  WITH CHECK ADD  CONSTRAINT [FK_UserSucUser] FOREIGN KEY([user_suc_usuario])
REFERENCES [gd_esquema].[Usuario] ([user_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [gd_esquema].[UsuarioSucursal] CHECK CONSTRAINT [FK_UserSucUser]
GO
ALTER DATABASE [GD2C2017] SET  READ_WRITE 
GO


CREATE PROCEDURE gd_esquema.MigrarSucursal
AS
BEGIN
	DECLARE sucursal_cursor CURSOR FOR
	SELECT Sucursal_Nombre, Sucursal_Dirección, Sucursal_Codigo_Postal
	FROM gd_esquema.Maestra
	WHERE Sucursal_Nombre IS NOT NULL and Sucursal_Dirección IS NOT NULL and Sucursal_Codigo_Postal IS NOT NULL
	GROUP BY Sucursal_Nombre, Sucursal_Dirección, Sucursal_Codigo_Postal
	
	DECLARE @nombre nvarchar(50);
	DECLARE @direccion nvarchar(50);
	DECLARE @codigo numeric(18,0);
	
	OPEN sucursal_cursor;
	FETCH sucursal_cursor INTO @nombre, @direccion, @codigo;

	WHILE (@@FETCH_STATUS = 0)
	BEGIN	
		INSERT INTO gd_esquema.Sucursal (sucu_nombre, sucu_direccion, sucu_codigo_postal) 
		VALUES (@nombre, @direccion, @codigo);
		FETCH sucursal_cursor INTO @nombre, @direccion, @codigo;
	 END 

	 CLOSE sucursal_cursor;
	 DEALLOCATE sucursal_cursor;
END
GO

CREATE PROCEDURE gd_esquema.MigrarClientes
AS
BEGIN
	DECLARE clientes_cursor CURSOR FOR
	SELECT [Cliente-Apellido], [Cliente-Nombre], Cliente_Direccion, [Cliente-Dni], Cliente_Mail, [Cliente-Fecha_Nac], Cliente_Codigo_Postal
	FROM gd_esquema.Maestra
	GROUP BY [Cliente-Apellido], [Cliente-Nombre], Cliente_Direccion, [Cliente-Dni], Cliente_Mail, [Cliente-Fecha_Nac],Cliente_Codigo_Postal

	DECLARE @codigo NUMERIC(18,0);
	DECLARE @direccion NVARCHAR(255);
	DECLARE @dni NUMERIC(18,0);
	DECLARE @mail NVARCHAR(255);
	DECLARE @fecha_de_nac DATETIME;
	DECLARE @nombre NVARCHAR(255);
	DECLARE @apellido NVARCHAR(255);
	
	OPEN clientes_cursor
	FETCH clientes_cursor INTO @apellido, @nombre, @direccion, @dni, @mail, @fecha_de_nac, @codigo;
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		INSERT INTO gd_esquema.Cliente (clie_apellido, clie_nombre, clie_direccion, clie_dni, clie_mail, clie_fecha_nac, clie_codigo_postal)
			   VALUES ( @apellido, @nombre, @direccion, @dni, @mail, @fecha_de_nac,@codigo);
		
		FETCH clientes_cursor INTO @apellido, @nombre, @direccion, @dni, @mail, @fecha_de_nac, @codigo;
		
	END
	
	CLOSE clientes_cursor;
	DEALLOCATE clientes_cursor;
END
GO

CREATE PROCEDURE gd_esquema.MigrarRubros
AS
BEGIN
	DECLARE rubros_cursor CURSOR FOR
	SELECT Empresa_Rubro, Rubro_Descripcion
	FROM gd_esquema.Maestra
	WHERE Empresa_Rubro IS NOT NULL and Rubro_Descripcion IS NOT NULL
	GROUP BY Empresa_Rubro, Rubro_Descripcion
	
	DECLARE @id numeric(18,0);
	DECLARE @descripcion nvarchar(50);
	
	OPEN rubros_cursor;
	FETCH rubros_cursor INTO @id, @descripcion;

	WHILE (@@FETCH_STATUS = 0)
	BEGIN	
		INSERT INTO gd_esquema.Rubro(rubr_id, rubr_detalle) 
		VALUES (@id, @descripcion);
		FETCH rubros_cursor INTO @id, @descripcion;
	 END 

	 CLOSE rubros_cursor;
	 DEALLOCATE rubros_cursor;
END
GO
