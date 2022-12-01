import { Component } from '@angular/core';
import { RandomService } from './services/random.service';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss']
})
export class AppComponent {
	firstVal: number = 5;
	secondVal: number = 7;

	loadingRandom: boolean = false;

	get total(): number {
		return this.firstVal + this.secondVal;
	}

	constructor(private randomService: RandomService) {
	}

	loadRandom(): void {
		this.loadingRandom = true;
		this.randomService.getRandomNumbers().subscribe({
			next: nums => {
				[this.firstVal, this.secondVal] = nums;
				this.loadingRandom = false;
			},
			error: _ => {
				this.loadingRandom = false;
			}
		});
	}
}
