import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoremIpsumGeneratorType } from "./lorem-ipsum-generator-type.enum";


@Component({
  selector: 'app-lorem-ipsum-component',
  templateUrl: './loremipsum.component.html',
})
export class LoremIpsumComponent {
  keys: any[];
  areaToGenerateIn = "Text will show up here";
  currentValue = LoremIpsumGeneratorType.Static;
  generators = LoremIpsumGeneratorType;

  onChange(currentValue) {
    this.currentValue = currentValue;
  }

  copyToClipboard() {
    document.addEventListener('copy', (e: ClipboardEvent) => {
      e.clipboardData.setData('text/plain', (this.areaToGenerateIn));
      e.preventDefault();
      document.removeEventListener('copy', null);
    });
    document.execCommand('copy');
  }

  generate() {
    this.http.get<string[]>(this.baseUrl +
      'interface/lorem_ipsum_generator/' +
      LoremIpsumGeneratorType[this.currentValue] +
      "/1/10").subscribe(result => {
        this.areaToGenerateIn = result[0];
      },
      error => console.error(error));
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.keys = Object.keys(this.generators).filter(Number);
  }
}
