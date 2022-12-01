import { TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';

import { MockComponent } from 'ng2-mock-component';
import { RandomService } from './services/random.service';
import { of } from 'rxjs';

describe('AppComponent', () => {
	beforeEach(async () => {
		await TestBed.configureTestingModule({
			declarations: [
				AppComponent,
				MockComponent({
					selector: 'app-number-input',
					inputs: [ 'value' ],
					outputs: [ 'valueChange' ]
				})
			],
			providers: [
				{
					provide: RandomService,
					useValue: jasmine.createSpyObj('RandomService', [ 'getRandomNumbers' ])
				}
				// {
				// 	provide: RandomService,
				// 	useValue: {
				// 		getRandomNumbers: jasmine.createSpy('getRandomNumbers')
				// 		// getRandomNumbers: () => of([3, 5])
				// 	}
				// }
			]
		}).compileComponents();
	});

	it('should create the app', () => {
		const fixture = TestBed.createComponent(AppComponent);
		const app = fixture.componentInstance;
		expect(app).toBeTruthy();
	});

	it('adds values', () => {
		const fixture = TestBed.createComponent(AppComponent);
		const app = fixture.componentInstance;

		app.firstVal = 13;
		app.secondVal = 17;

		expect(app.total).toBe(30);
	});

	it('show total on page', () => {
		const fixture = TestBed.createComponent(AppComponent);
		fixture.detectChanges();
		const app = fixture.componentInstance;

		app.firstVal = 13;
		app.secondVal = 17;

		fixture.detectChanges();

		const compiled = fixture.nativeElement as HTMLElement;
		expect(compiled.querySelector('strong')?.textContent).toContain('30');
	});

	it('gets numbers from service', () => {
		const mock = <jasmine.SpyObj<RandomService>> TestBed.inject(RandomService);
		mock.getRandomNumbers.and.returnValue(of([37, 43]));

		const fixture = TestBed.createComponent(AppComponent);
		const app = fixture.componentInstance;

		fixture.detectChanges();

		app.loadRandom();

		expect(app.firstVal).toBe(37);
		expect(app.secondVal).toBe(43);
	});
});
