import { Injectable } from '@angular/core';
import { isDevMode } from '@angular/core';

@Injectable()
export class Configuration {
    public ApiServer = 'http://localhost:4200/';
    public ApiUrl = 'api/';
    public ServerWithApiUrl: string = this.ApiServer + this.ApiUrl;

    constructor() {
        if (isDevMode()) {
            this.ApiServer = 'http://localhost:4201/';
            this.ServerWithApiUrl = this.ApiServer + this.ApiUrl;
            console.log('ApiServer=' + this.ApiServer);
            console.log('ServerWithApiUrl=' + this.ServerWithApiUrl);
        }
    }
}