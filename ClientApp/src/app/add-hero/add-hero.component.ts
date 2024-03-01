import { Component } from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {HeroesService} from "../heroes/heroes.service";
import {AddHero} from "./add-hero";
import {Router} from "@angular/router";

@Component({
  selector: 'app-hero-component',
  templateUrl: './add-hero.component.html',
  styleUrls: ['./add-hero.component.css']
})
export class AddHeroComponent {
  errors: any = [];

  heroForm = this.formBuilder.group({
    name: ['', [Validators.required, Validators.maxLength(100)]],
    alias: ['', [Validators.required, Validators.maxLength(50)]],
    brand: ['', [Validators.required, Validators.maxLength(100)]],
  });
  constructor(private formBuilder: FormBuilder,
              private service: HeroesService,
              private router: Router) {}

  onSubmit() {
    const hero = this.heroForm.value as AddHero;
    this.service.create(hero).subscribe({
        next: _ => this.router.navigate(['/']),
        error: error => {
          this.errors = error;
        }
      })
  }
}
