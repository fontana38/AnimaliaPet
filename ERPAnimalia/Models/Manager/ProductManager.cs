using ERPAnimalia.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Http.ModelBinding;


namespace ERPAnimalia.Models
{
    public class ProductManager
    {
        public static AnimaliaPetShopEntities db { get; set; }

        public TransferToFreeProductManager ProductOpenManagers { get; set; }

        public List<ProductListModel> map;
        private static readonly Object obj = new Object();



        public ProductManager()
        {

            db = Factory.Factory.CreateContextDataBase();

        }

        public void AddProduct(Product product)
        {
            try
            {
                db = Factory.Factory.CreateContextDataBase();
                db.Product.Add(product);

                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }

        }

        public void CreateProduct(ProductModels product)
        {
            try
            {

                var productDb = MapperObject.CreateProductDb(product);
                db.Product.Add(productDb);

                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void SaveProduct(ProductModels product)
        {
            using (var context = new AnimaliaPetShopEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {

                        var productDb = MapperObject.CreateProductDb(product);

                        //AddNewProduct
                        AddProduct(productDb);

                        context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception exepction)
                    {
                        dbContextTransaction.Rollback();
                        throw exepction;
                    }
                }
            }
        }


        public void DeleteProduct(ProductModels product)
        {

            var deleteProduct = db.Product.Find(product);
            db.Product.Remove(deleteProduct);
            db.SaveChanges();

        }

        public List<CategoryModel> GetCategoryList()
        {

            var CategoryList = db.Category.ToList();
            var map = MapperObject.CreateCategoryList(CategoryList);
            return map;

        }

        public List<SubCategoryModel> GetSubCategoryList()
        {

            var CategoryList = db.SubCategory.ToList();
            var map = MapperObject.CreateSubCategoryList(CategoryList);
            return map;

        }

        public virtual ProductModels GetProductById(Guid id)
        {

            var productById = db.Product.Find(id);
            var productMap = MapperObject.CreateProductModel(productById);

            if (productMap.kg != null)
            {
                productMap.kg = Math.Round(productMap.kg.Value, 2);
            }

            productMap.Category = GetCategoryList();
            productMap.SubCategory = GetSubCategoryList();
            productMap.TamanoMascotaList = GetTamañoMascota();
            return productMap;
        }

        public void EditProduct(ProductModels product)
        {

            var id = product.IdProducto;
            var productById = db.Product.Find(id);
            var productDb = MapperObject.EditProductDb(product, productById);

            db.SaveChanges();

        }
        public List<CategoryModel> GetCategory()
        {        
            var category = db.Category.ToList();
           
            return MapperObject.CreateCategoryList(category);
        }

        public List<SubCategoryModel> GetSubCategory()
        {
           
            var subCategory = db.SubCategory.ToList();

            return MapperObject.CreateSubCategoryList(subCategory);
        }

        public List<TipoAnimalModel> GetTipoAnimal()
        {

            var tipoAnimal = db.TipoAnimal.ToList();

            return MapperObject.CreateTipoAnimalList(tipoAnimal);
        }

        public List<TamanoMascotaModel> GetTamañoMascota()
        {
            
            var tamañoMascota = db.TamanoMascota.ToList();

            return MapperObject.CreateTamañoMascotaList(tamañoMascota);
        }

        public void Delete(Guid id)
        {
            
           
            var productById = db.Product.Find(id);

            if(productById != null)
            {
                db.Product.Remove(productById);
                db.SaveChanges();
            }
           
        }

        public ProductModels NewProductModel()
        {
           return Factory.Factory.NewProductModel();
        }

       
        public List<ProductModels> GetProductList(int? page, int? limit, string sortBy, string direction, string searchString, string idCategory, string idSubCategory, string idTamañoMascota, out int total)
        {
            try
            {
                int category = 0;
                int subCategory = 0;
                int tamañoMascota = 0;



                var map = new List<ProductModels>();

                map = MapProduct();

                if(!String.IsNullOrEmpty(idCategory) && idCategory != "0")
                {
                    category = Convert.ToInt16(idCategory);
                    map = map.Where(x => x.IdCategory== category).ToList();
                }

                if (!String.IsNullOrEmpty(idSubCategory) && idSubCategory != "0")
                {
                    subCategory = Convert.ToInt16(idSubCategory);
                    map = map.Where(x => x.IdSubCategory == subCategory).ToList();
                }

                if (!String.IsNullOrEmpty(idTamañoMascota) && idTamañoMascota != "0")
                {
                    tamañoMascota = Convert.ToInt16(idTamañoMascota);
                    map = map.Where(x => x.IdTamanoMascota == tamañoMascota).ToList();
                }

                if (!string.IsNullOrWhiteSpace(searchString))
                {
                    map = GetProductListQuery(map, searchString);
                }

                total = map.Count();
                
                
                var productQueryable = map.AsQueryable();


                if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
                {

                    if (direction.Trim().ToLower() == "asc")
                    {
                        productQueryable = SortHelper.OrderBy(productQueryable, sortBy);
                    }
                    else
                    {
                        productQueryable = SortHelper.OrderByDescending(productQueryable, sortBy);
                    }
                }
                if (page.HasValue && limit.HasValue)
                {
                    int start = (page.Value - 1) * limit.Value;
                    productQueryable = productQueryable.Skip(start).Take(limit.Value);
                }

                return productQueryable.ToList();
            }
            
            catch (Exception ex)
            {            
                throw new Exception(ex.Message);
            }
            
        }



        public List<ProductModels> GetProductList(int? page, int? limit, string sortBy, string direction, string searchString, out int total)
        {
            var map = new List<ProductModels>();
            var listCode = new List<ProductModels>();
            var listCodeBarra = new List<ProductModels>();
            double codigo=0;
            
            map = MapProduct();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                try
                {

                    codigo = double.Parse(searchString);

                }
                catch (FormatException e)
                {
                    codigo = 0;
                }

                if(codigo!=0)
                {
                    listCode = map.Where(p => (p.Codigo == codigo)).ToList();
                    listCodeBarra = map.Where(p => (p.CodigoBarra == searchString)).ToList();
                }

                else {

                    map = GetProductListQuery(map, searchString);
                }

            }

            if(listCode.Count != 0)
            {
                map = listCode;
            }

            if (listCodeBarra.Count != 0)
            {
                map = listCodeBarra;
            }

            total = map.Count();

            var productQueryable = map.AsQueryable();


            if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
            {

                if (direction.Trim().ToLower() == "asc")
                {
                    productQueryable = SortHelper.OrderBy(productQueryable, sortBy);
                }
                else
                {
                    productQueryable = SortHelper.OrderByDescending(productQueryable, sortBy);
                }
            }
            if (page.HasValue && limit.HasValue)
            {
                int start = (page.Value - 1) * limit.Value;
                productQueryable = productQueryable.Skip(start).Take(limit.Value);
            }

            return productQueryable.ToList();
        }


        public List<ProductModels> GetProductNotSelected(Guid? idClient, int? page, int? limit, string sortBy, string direction, string searchString, out int total)
        {
            total = 0;
            var map = new List<ProductModels>();
            map = MapProduct();

            if (idClient != null)
            {



                var productList = db.IdClienteIdProducto.Where(x => x.IdCliente == idClient).ToList();



                foreach (var item in productList)
                {
                    var deleteProduct = map.Where(x => x.IdProducto == item.IdProducto).First();
                    map.Remove(deleteProduct);
                }

            }


            if (!string.IsNullOrWhiteSpace(searchString))
            {
                map = GetProductListQuery(map, searchString);
            }

            total = map.Count();

            var productQueryable = map.AsQueryable();

            if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
            {

                if (direction.Trim().ToLower() == "asc")
                {
                    productQueryable = SortHelper.OrderBy(productQueryable, sortBy);
                }
                else
                {
                    productQueryable = SortHelper.OrderByDescending(productQueryable, sortBy);
                }
            }
            if (page.HasValue && limit.HasValue)
            {
                int start = (page.Value - 1) * limit.Value;
                productQueryable = productQueryable.Skip(start).Take(limit.Value);
            }

            return productQueryable.ToList();
       
        }



        public List<ProductModels> GetProductListByIdClient(Guid? idClient,int? page, int? limit, string sortBy, string direction, string searchString, out int total)
        {
            total = 0;
            var productList = new List<ProductModels>();

            if(idClient != null)
            {
                var pc = db.IdClienteIdProducto.Where(x => x.IdCliente == idClient).ToList();

                foreach (var itemproduct in pc)
                {
                    var product = GetProductById(itemproduct.IdProducto.Value);
                    productList.Add(product);
                }


                total = productList.Count();

                var productQueryable = productList.AsQueryable();

                if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
                {

                    if (direction.Trim().ToLower() == "asc")
                    {
                        productQueryable = SortHelper.OrderBy(productQueryable, sortBy);
                    }
                    else
                    {
                        productQueryable = SortHelper.OrderByDescending(productQueryable, sortBy);
                    }
                }
                if (page.HasValue && limit.HasValue)
                {
                    int start = (page.Value - 1) * limit.Value;
                    productQueryable = productQueryable.Skip(start).Take(limit.Value);
                }
                return productQueryable.ToList();
            }

            return new List<ProductModels>();
        }

        public List<ProductModels> GetProductListByIdProvider(Guid? idProvider, int? page, int? limit, string sortBy, string direction, string searchString, out int total)
        {
            total = 0;
            var productList = new List<ProductModels>();

            if (idProvider != null)
            {
                var pc = db.IdProveedorProducto.Where(x => x.IdProveedor == idProvider).ToList();

                foreach (var itemproduct in pc)
                {
                    var product = GetProductById(itemproduct.IdProducto.Value);
                    productList.Add(product);
                }


                total = productList.Count();

                var productQueryable = productList.AsQueryable();

                if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
                {

                    if (direction.Trim().ToLower() == "asc")
                    {
                        productQueryable = SortHelper.OrderBy(productQueryable, sortBy);
                    }
                    else
                    {
                        productQueryable = SortHelper.OrderByDescending(productQueryable, sortBy);
                    }
                }
                if (page.HasValue && limit.HasValue)
                {
                    int start = (page.Value - 1) * limit.Value;
                    productQueryable = productQueryable.Skip(start).Take(limit.Value);
                }
                return productQueryable.ToList();
            }

            return new List<ProductModels>();
        }
        public List<ProductModels> GetProducBugtList(List<ProductModels> list)
        {

            var listProduct = list.Where(x => x.IdSubCategory == (int)Enumeration.Subcategory.Bolsa || x.IdCategory == (int)Enumeration.Category.Accesorios).ToList();
            return listProduct;

        }



        public List<ProductModels> GetProductNotSelectedProvider(Guid? idProvider, int? page, int? limit, string sortBy, string direction, string searchString, out int total)
        {
            total = 0;
            var map = new List<ProductModels>();
            map = MapProduct();

            if (idProvider != null)
            {



                var productList = db.IdProveedorProducto.Where(x => x.IdProveedor == idProvider).ToList();



                foreach (var item in productList)
                {
                    var deleteProduct = map.Where(x => x.IdProducto == item.IdProducto).First();
                    map.Remove(deleteProduct);
                }

            }


            if (!string.IsNullOrWhiteSpace(searchString))
            {

                map = GetProductListQuery(map, searchString);

            }

            total = map.Count();

            var productQueryable = map.AsQueryable();

            if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
            {

                if (direction.Trim().ToLower() == "asc")
                {
                    productQueryable = SortHelper.OrderBy(productQueryable, sortBy);
                }
                else
                {
                    productQueryable = SortHelper.OrderByDescending(productQueryable, sortBy);
                }
            }
            if (page.HasValue && limit.HasValue)
            {
                int start = (page.Value - 1) * limit.Value;
                productQueryable = productQueryable.Skip(start).Take(limit.Value);
            }

            return productQueryable.ToList();

        }


        public List<ProductModels> GetProducBug(List<ProductModels> list)
        {

            var listProduct = list.Where(x => x.IdSubCategory == (int)Enumeration.Subcategory.Bolsa && x.IdCategory == (int)Enumeration.Category.Alimento && x.Cantidad >=1).ToList();
            return listProduct;

        }

        public List<ProductModels> GetProducLooseList(List<ProductModels> list)
        {

            var listProduct = list.Where(x => x.IdSubCategory == (int)Enumeration.Subcategory.Suelto && x.IdCategory == (int)Enumeration.Category.Alimento).ToList();
            return listProduct;

        }

      
        public List<ProductModels> MapProduct()
        {
            lock (obj)
            {

                var productList = db.Product.ToList();
                var category = db.Category.ToList();
                var subcategoria = db.SubCategory.ToList();
                var tamanoList = db.TamanoMascota.ToList();

                return MapperObject.CreateProductList(productList, category, subcategoria,tamanoList);
            }
        }


        public List<ProductModels> MapProductBySucursal(List<SucursalProductoModel> sucPro)
        {
            List<Product> productList = new List<Product>();
            Category category;
            SubCategory subcategoria;
            TamanoMascota tamanoList;
            lock (obj)
            {
                
                foreach (var item in sucPro)
                {
                    var productListItem = db.Product.Where(x => x.IdProducto == item.Product.IdProducto).First();
                     category = db.Category.Where(x => x.IdCategory == item.Product.IdCategory).First();
                    subcategoria = db.SubCategory.Where(x => x.IdSubCategory == item.Product.IdSubCategory).First();
                    tamanoList = db.TamanoMascota.Where(x=> x.IdTamanoMascota==item.Product.IdTamanoMascota).First();
                    productList.Add(productListItem);
                }

               

                return MapperObject.CreateProductListBySucursal(productList, category, subcategoria, tamanoList);
            }
        }

        public void RemoveModelView(ModelStateDictionary modelState)
        {
            modelState.Remove("Codigo");
            modelState.Remove("Description");
            modelState.Remove("quantity");
            modelState.Remove("IdCategory");
            modelState.Remove("IdSubCategory");
            modelState.Remove("IdTamanoMascota");
        }


        public void SaveProductToLoose(Guid? idBug,Guid? idLoose, string precioCosto, string precioVenta)
        {
            using (var context = new AnimaliaPetShopEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Product productBug = db.Product.Find(idBug);
                        Product productLoose = db.Product.Find(idLoose);
                        var totalQuantity = productLoose.TotalKg + productBug.Kg;


                        var precioCostoNew = ((Math.Round(productLoose.TotalKg.Value,2) * Math.Round(productLoose.PrecioCosto.Value,2)) + ((Math.Round(productBug.Kg.Value,2)) * (Convert.ToDecimal(precioCosto) ))) / Math.Round(totalQuantity.Value,2);
                        productLoose.PrecioCosto = precioCostoNew;
                        productLoose.PrecioVenta = Convert.ToDecimal(precioVenta);
                        productLoose.TotalKg = productLoose.TotalKg + productBug.Kg;

                        productBug.TotalKg = productBug.TotalKg - productBug.Kg;
                        productBug.Cantidad = productBug.Cantidad - 1;

                       
                        db.SaveChanges();

                        dbContextTransaction.Commit();


                    }
                    catch (Exception exepction)
                    {
                        dbContextTransaction.Rollback();
                        throw exepction;
                    }


                    // producto.First().PrecioCosto = Convert.ToDecimal((Convert.ToDecimal(producto.First().Cantidad) * producto.First().PrecioCosto) + (Convert.ToDecimal(cantidad[i]) * Convert.ToDecimal(precioCosto[i]))) / cantidadTotal;

                }
            }
         }


        public ProductModels CalculteRentabilidad(ProductModels product)
        {
   
            if (product.PrecioVenta != '0' && product.PrecioCosto != '0')
            {
                if (product.IdSubCategory == 1)
                {
                    var kgXP = (product.PrecioCosto / product.kg );
                    var rentPesos = (product.PrecioVenta - kgXP);
                    var rentPorc = (1 - (kgXP / product.PrecioVenta)) * 100;
                     product.Rentabilidad = Math.Round(rentPorc.Value,2);
                    product.RentabilidadPesos = Math.Round(rentPesos.Value,2);

                }
                else
                {
                    var rentPesos = (product.PrecioVenta - product.PrecioCosto);
                    var rentPorc = (1 - (product.PrecioCosto / product.PrecioVenta)) * 100;
                    product.Rentabilidad = Math.Round( rentPorc,2);
                    product.RentabilidadPesos = Math.Round(rentPesos,2);

                }

               

            }
            return product;
        }



        private List<ProductModels> GetProductListQuery(List<ProductModels> list,string searchString)
        {
            list = list.Where(p => (p.CodigoBarra != null) ? (((p.CodigoBarra.ToUpper().StartsWith(searchString.ToUpper()) || p.CodigoBarra.ToUpper().EndsWith(searchString.ToUpper())) || (p.Codigo.ToString().ToUpper().StartsWith(searchString.ToUpper()) || p.Codigo.ToString().ToUpper().EndsWith(searchString.ToUpper())) ||
               (p.Descripcion1.ToUpper().StartsWith(searchString.ToUpper()) || p.Descripcion1.ToUpper().EndsWith(searchString.ToUpper())) ||
               (p.Marca.ToUpper().StartsWith(searchString.ToUpper()) || p.Marca.ToUpper().EndsWith(searchString.ToUpper()))
               )) : ((p.Codigo.ToString().StartsWith(searchString.ToUpper()) || p.Codigo.ToString().ToUpper().EndsWith(searchString.ToUpper())) ||
               (p.Descripcion1.ToUpper().StartsWith(searchString.ToUpper()) || p.Descripcion1.ToUpper().EndsWith(searchString.ToUpper())) ||
               (p.Marca.ToUpper().StartsWith(searchString.ToUpper()) || p.Marca.ToUpper().EndsWith(searchString.ToUpper())))).ToList();

            return list;
        }


           
    }
}