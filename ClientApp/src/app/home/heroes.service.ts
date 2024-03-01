import {Inject, Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable} from 'rxjs';

import { Hero } from './hero';


@Injectable()
export class HeroesService {

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
  }

  get(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.baseUrl + 'heroes');
  }
}
