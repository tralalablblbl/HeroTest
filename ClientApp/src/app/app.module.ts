import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HeroesComponent } from './heroes/heroes.component';
import { AddHeroComponent } from './add-hero/add-hero.component';
import { HeroesService } from "./heroes/heroes.service";
import {JsonPipe, NgFor} from "@angular/common";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HeroesComponent,
    AddHeroComponent
   ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-uni8ersal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    JsonPipe,
    NgFor,
    RouterModule.forRoot([
      { path: '', component: HeroesComponent, pathMatch: 'full' },
      { path: 'add-hero', component: AddHeroComponent, pathMatch: 'full' }
    ])
  ],
  providers: [HeroesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
