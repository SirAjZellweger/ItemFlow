import { EnvironmentProviders, Provider } from '@angular/core';
import { environment } from './environment';
import { ENVIRONMENT } from './environment.token';

export const provideEnvironment = (): (Provider | EnvironmentProviders)[] => [
  {
    provide: ENVIRONMENT,
    useValue: environment,
  },
];
