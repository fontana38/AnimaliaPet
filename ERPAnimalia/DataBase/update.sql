USE AnimaliaPetShop
--//Update productos , la cantidad y el precio
update Product
set Product.Cantidad = ac.F11,Product.PrecioCosto=ac.f8,Product.PrecioVenta=ac.f7,Product.RentabilidadPesos=ac.f9,Product.Rentabilidad=ac.f10
FROM [dbo].['VTA#DIARIA 6$'] as ac
where Product.Codigo=f2


select * from Product
Product.Cantidad = ac.F11,Product.PrecioCosto=ac.f8,Product.PrecioVenta=ac.f7,Product.RentabilidadPesos=ac.f9,Product.Rentabilidad=ac.f10
FROM [dbo].['VTA#DIARIA 6$'] as ac
where Product.Marca = ac.f4 and Product.Descripcion1=ac.f5 and Product.Kg=ac.F6

--//Update Code product table
update Product
set Product.Codigo = ac.F2
FROM [dbo].['VTA#DIARIA 6$'] as ac
where Product.Marca = ac.f4 and Product.Descripcion1=ac.f5 and Product.Cantidad=ac.f11


--//Update Suelto
update Product
set Product.Cantidad = ac.F11,Product.PrecioCosto=ac.f8,Product.PrecioVenta=ac.f7,Product.RentabilidadPesos=ac.f9,Product.Rentabilidad=ac.f10,IdSubCategory=2
 from ['VTA#DIARIA 6$'] as ac
where f6=1 and f4 in ('WHISKAS','PERFORMANCE','CAT CHOW','RAZA','VORAZ', '7 VIDAS','SABROSITOS', 'GATI','AGILITY', 'PEDIGREE','NUTRIBON', 'NUTRICARE','KONGO'
 , 'DOGUI' , 'MASCOTITO')
 or f5 in ('ARROZ SUELTO SABORIZADO','ARROZ SUELTO COMUN','ALIM. HAMSTER','ALIM. CONEJOS','GIRASOL','ALPISTE','MEZCLA PARA CANARIOS CON VITAMINA','MEZCLA PARA CANARIOS',
 'MIL GRANOS','BALANCEADO  POLLO   BB X 4 KG','BALANCEADO POLLO ADULTO X 4KG') 


 


select * from product
 where LEN(codigo) <= 2

--//Updat
 select * from producte productos , la cantidad y el precio
update Product
set Product.Descripcion2='PERRO'
FROM product
where Product.Descripcion2 is null

--//Update categoria , y subcategoria para accesorios
update Product
set Product.IdCategory=1, Product.IdSubCategory=2
FROM product
where IdCategory is null and IdSubCategory is null and kg is null

--//Update categoria , y subcategoria para alimento
update Product
set Product.IdCategory=1, Product.IdSubCategory=2
FROM product
where IdCategory is null and IdSubCategory is null

delete from Product
where marca is null

--Inserta nuevos productos que no estan en la base
INSERT INTO product (Marca, Descripcion1,Cantidad,kg,IdProducto,RentabilidadPesos,Rentabilidad,PrecioVenta,PrecioCosto,TotalKg)
SELECT a.f4, a.f5, a.f11,a.f6,NEWID(),a.f9,a.f10,a.f7,a.f8,(a.f11 * a.f6)
FROM  (
SELECT  ac.f4, ac.f5, ac.f11,ac.f6,ac.f9,ac.f10,ac.f7,ac.f8
FROM [dbo].['VTA#DIARIA 6$'] as ac
WHERE ac.f5 NOT IN (SELECT  Product.Descripcion1 FROM Product))a


update ['VTA#DIARIA 5$']
set f11=0
where f11 is null
update  ['VTA#DIARIA 5$']
set f6=0
where f6 is null




select * from Product where CodigoBarra is null 
ALTER TABLE ['VTA#DIARIA 5$']
ALTER COLUMN f6 decimal(18,4);


