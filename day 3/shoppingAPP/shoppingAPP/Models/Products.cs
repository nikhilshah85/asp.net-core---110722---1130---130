namespace shoppingAPP.Models
{
    public class Products
    {
        public int pId { get; set; }
        public string pName { get; set; }
        public string pCategory { get; set; }
        public double pPrice { get; set; }
        public bool pIsInStock { get; set; }


        static List<Products> pList = new List<Products>()
        {
            new Products(){ pId = 101, pName="Pepsi", pCategory="Cold-Drink", pIsInStock=true, pPrice=50},
            new Products(){ pId = 102, pName="Coke", pCategory="Cold-Drink", pIsInStock=true, pPrice=50},
            new Products(){ pId = 103, pName="Maggie", pCategory="Fast-Food", pIsInStock=false, pPrice=50},
            new Products(){ pId = 104, pName="IPhone", pCategory="Electronics", pIsInStock=true, pPrice=50},
            new Products(){ pId = 105, pName="2 States", pCategory="Book", pIsInStock=true, pPrice=50},
            new Products(){ pId = 106, pName="Sandwitch", pCategory="Fast-Food", pIsInStock=false, pPrice=50}
        };

        public List<Products> GetAllProducts()
        {
            return pList;
        }

        public Products GetProductById(int id)
        {
            var p = (from pr in pList
                     where pr.pId == id
                     select pr).Single();         

            if (p != null)
            {
                return p;
            }
            throw new Exception("Product Not Found");
        }

        public string AddProduct(Products newProduct)
        {
            pList.Add(newProduct);
            return "Product Added Successfully";
        }

        public string DeleteProduct(int id)
        {
            var p = (from pr in pList
                     where pr.pId == id
                     select pr).Single();

            pList.Remove(p);
            return "Product Removed Successfully";
        }

        public string UpdateProduct(Products changes)
        {
            var p = (from pr in pList
                     where pr.pId == changes.pId
                     select pr).Single();

            p.pName = changes.pName;
            p.pCategory = changes.pCategory;
            p.pPrice = changes.pPrice;
            p.pIsInStock = changes.pIsInStock;

            return "Product Updated Successfully";
        }

    }
}
