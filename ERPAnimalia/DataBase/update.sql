USE AnimaliaPetShop
--//Update productos , la cantidad y el precio
update Product
set Product.Cantidad = ac.F11,Product.PrecioCosto=ac.f8,Product.PrecioVenta=ac.f7,Product.RentabilidadPesos=ac.f9,Product.Rentabilidad=ac.f10
FROM Enero as ac
where Product.Marca = ac.f4 and Product.Descripcion1=ac.[ ] and Product.Kg=ac.F6




--//Update productos , la cantidad y el precio
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
SELECT a.f4, a.[ ], a.f11,a.f6,NEWID(),a.f9,a.f10,a.f7,a.f8,(a.f11*a.f6)
FROM  (
SELECT  ac.f4, ac.[ ], ac.f11,ac.f6,ac.f9,ac.f10,ac.f7,ac.f8
FROM Enero as ac
WHERE ac.[ ] NOT IN (SELECT  Product.Descripcion1 FROM Product) and ac.f11 != 0 




select * from Product where CodigoBarra is null 


