import { Component } from '@angular/core';
import {HeroesService} from "./heroes.service";
import {Hero} from "./hero";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers:  [ HeroesService ],
})
export class HomeComponent {
  public heroes: Hero[] = [];

  constructor(
    private service: HeroesService) {
  }

  ngOnInit() {
    this.service.get().subscribe((heroes: Hero[]) => {
      this.heroes = heroes;
    });
  }

}
