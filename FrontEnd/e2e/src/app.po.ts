import { browser, by, element } from 'protractor';

export class AppPage {
  navigateTo() {
    return browser.get(browser.baseUrl) as Promise<any>;
  }

  getTitleText() {
    return element(by.css('app-root h1')).getText() as Promise<string>;
  }

  getSubTitleText() {
    return element(by.css('h2.heading')).getText() as Promise<string>;
  }

  getHulkInTable(){
    return element(by.css('.heroes div:nth-child(1)')).getText() as Promise<string>;
  }
}
