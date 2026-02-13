import { provideZoneChangeDetection } from "@angular/core";
import { provideHttpClient } from '@angular/common/http';
import { platformBrowser } from '@angular/platform-browser';
import { AppModule } from './app/app.module';

platformBrowser().bootstrapModule(AppModule, {
  applicationProviders: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideHttpClient()
  ]
})
  .catch(err => console.error(err));
