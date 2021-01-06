import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ProductComponent } from './product/product.component';
import { ExceptionHandler } from './shared/ExceptionHandler';
import { ProductService } from './shared/services/productService';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProductComponent,    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,    
    RouterModule.forRoot([
      { path: '', component: ProductComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent }
    ])
  ],
  providers: [ProductService,
    // General Exception Handling.
    { provide: ErrorHandler, useClass: ExceptionHandler }
   ],
  bootstrap: [AppComponent]
})
export class AppModule { }
