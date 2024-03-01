import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable} from 'rxjs';

import { Hero } from './hero';
import { AddHero } from "../add-hero/add-hero";


@Injectable()
export class HeroesService {

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
  }

  get(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.baseUrl + 'heroes');
  }

  delete(id: number): Observable<unknown> {
    return this.http.delete(`${this.baseUrl}heroes/${id}`);
  }

  create(hero: AddHero): Observable<Hero> {
    return this.http.post<Hero>(this.baseUrl + 'heroes', hero);
  }
}
