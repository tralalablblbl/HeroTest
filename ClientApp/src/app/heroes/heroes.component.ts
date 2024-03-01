import { Component } from '@angular/core';
import {HeroesService} from "./heroes.service";
import {Hero} from "./hero";

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  providers:  [ HeroesService ],
})
export class HeroesComponent {
  public heroes: Hero[] = [];

  constructor(
    private service: HeroesService) {
  }

  ngOnInit() {
    this.load();
  }

  load() {
    this.service.get().subscribe((heroes: Hero[]) => {
      this.heroes = heroes;
    });
  }
  delete(hero: Hero){
    if(confirm(`Are you sure to delete ${hero.Name}?`)) {
      this.service.delete(hero.Id).subscribe(_ => this.load());
    }
  }
}
