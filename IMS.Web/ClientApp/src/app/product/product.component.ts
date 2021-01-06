import { Component } from '@angular/core';
import { ProductService } from '../shared/services/productService';


@Component({
  templateUrl: './product.component.html'
})
export class ProductComponent {

  // #region Vars.
  products: Product[];  
  code: string = "";
  title: string = "";
  date: Date;
  qtyType: string = "<";
  productQty: number = null;
  disabeNew: boolean = true;
  isAddClicked: boolean = false;
  // #endregion

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    // Load all the data in the table.
    this.getProductsData();
  }

  getProductsData() {    
    this.productService.searchProducts({ code: this.code, title: this.title, creationDate: !this.date ? null : this.date, quantity: this.productQty, qtyOperator: this.qtyType }).subscribe((result: Product[]) => {
      result.forEach(function (item) {
        item.editMode = false;
      });
      this.products =  result;
      this.disabeNew = false;

    }, error => console.error(error));
  }

  filter() {    
    this.getProductsData();
  }

  clear() {
    this.code = "";
    this.title = "";
    this.date = undefined;
    this.qtyType = "<";
    this.productQty = null;
    this.filter();
  }



  addProduct() {    
    this.disabeNew = true;
    this.isAddClicked = true;
    this.reset();
    let product: Product = {} as Product;
    product.editMode = true;

    if (!this.products)
      this.products = [];
    this.products.push(product);
  }
  edit(index) {    
    this.disabeNew = true;
    this.reset();
    this.products[index].editMode = true;
  }


  save(product: Product) {    
    //var obj = this.products[index];
    if (this.validate(product)) {
      if (product.id) {
        //Edit
        this.productService.editProduct(product).subscribe((result) => {
          if (result > 0) {
            this.getProductsData();
            alert('The record Edit sucssfully');
          }
          else {
            alert('Error Occurred');
          }
        }, error => console.error(error));
      } else {
        //Insert
        this.productService.addProduct(product).subscribe((result) => {
          if (result > 0) {
            this.getProductsData();
            this.isAddClicked = false;
            alert('The recored add sucssfully');
          }
          else {
            alert('Error Occurred');
          }
        }, error => console.error(error));
      }
    }
    else {
      alert('Please enter all required fields !');
    }
  }

  validate(product) {
    if (product.code && product.quantity && product.title) {
      return true;
    }
    else {
      return false;
    }
  }

  cancel(product: Product, index) {
    if (product.id > 0) {
      this.reset();
      this.products[index].editMode = false;
    }
    else {
      this.products.splice(index, 1);
    }
    this.disabeNew = false;
    this.isAddClicked = false;
  }
  delete(item: Product) {
    if (confirm(`Are you sure you want delete this product : (${item.title})`)) {
      this.productService.deleteProduct(item.id).subscribe(() => {
        alert('The recored Deleted sucssfully');
        this.products.splice(this.products.indexOf(item), 1);
      },
        error => { console.error(error) });
    }
  }
  reset() {
    this.products.forEach(function (item) {
      item.editMode = false;
    });
  }
}




