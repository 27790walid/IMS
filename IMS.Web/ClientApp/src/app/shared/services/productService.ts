import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiURL = "http://localhost:52780";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  constructor(private httpClient: HttpClient) { }

  addProduct(product): Observable<any> {
    return this.httpClient.post<any>(`${this.apiURL}/api/Product/AddProduct/`, JSON.stringify(product), this.httpOptions)
  }

  editProduct(product): Observable<any> {
    return this.httpClient.post<any>(`${this.apiURL}/api/Product/EditProduct/`, JSON.stringify(product), this.httpOptions);
  }
 
  searchProducts(productSearch: any): Observable<any[]> {
    let url: string = `${this.apiURL}/api/Product/SearchProducts`;
    return this.httpClient.post<any[]>(url, JSON.stringify(productSearch), this.httpOptions);
  }

  getProductById(id): Observable<any> {
    return this.httpClient.get<any[]>(`${this.apiURL}/api/Product/GetProductById/${id}`, this.httpOptions);
  }

  deleteProduct(id) {
    return this.httpClient.delete<any>(`${this.apiURL}/api/Product/DeleteProduct/${id}`, this.httpOptions);
  }
}
