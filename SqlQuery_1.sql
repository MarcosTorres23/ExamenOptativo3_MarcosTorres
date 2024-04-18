BEGIN;


DROP TABLE IF EXISTS public.clientes;

CREATE TABLE IF NOT EXISTS public.clientes
(
    id integer NOT NULL DEFAULT nextval('clientes_id_seq'::regclass),
    id_banco integer NOT NULL,
    nombre character varying COLLATE pg_catalog."default" NOT NULL,
    apellido character varying COLLATE pg_catalog."default" NOT NULL,
    documento character varying COLLATE pg_catalog."default" NOT NULL,
    direccion character varying COLLATE pg_catalog."default" NOT NULL,
    mail character varying COLLATE pg_catalog."default" NOT NULL,
    celular character varying COLLATE pg_catalog."default" NOT NULL,
    estado character varying COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT clientes_pkey PRIMARY KEY (id)
);

DROP TABLE IF EXISTS public.facturas;

CREATE TABLE IF NOT EXISTS public.facturas
(
    id integer NOT NULL DEFAULT nextval('facturas_id_seq'::regclass),
    id_cliente integer NOT NULL,
    nro_factura character varying COLLATE pg_catalog."default" NOT NULL,
    fecha_hora date NOT NULL,
    total integer NOT NULL,
    total_iva5 character varying COLLATE pg_catalog."default" NOT NULL,
    total_iva10 character varying COLLATE pg_catalog."default" NOT NULL,
    total_iva character varying COLLATE pg_catalog."default" NOT NULL,
    total_letras character varying COLLATE pg_catalog."default" NOT NULL,
    sucursal character varying COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT facturas_pkey PRIMARY KEY (id)
);

ALTER TABLE IF EXISTS public.facturas
    ADD CONSTRAINT id_cliente FOREIGN KEY (id_cliente)
    REFERENCES public.clientes (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;

END;