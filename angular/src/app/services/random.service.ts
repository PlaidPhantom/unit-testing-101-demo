import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
	providedIn: 'root'
})
export class RandomService {
	static readonly URL = 'https://www.random.org/integers/?num=2&min=1&max=100&format=plain&col=1&base=10';

	constructor(private http: HttpClient) { }

	getRandomNumbers(): Observable<[number, number]> {
		return this.http
			.get(RandomService.URL, {observe: 'body', responseType: 'text' })
			.pipe(map(response => {
				var split = response.split('\n');
				return [ parseInt(split[0], 10), parseInt(split[1], 10) ];
			}));
	}
}
