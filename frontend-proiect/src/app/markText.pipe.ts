import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'markText'
})
export class MarkTextPipe implements PipeTransform {

  transform(value: any, ...args: any[]): any {
    return "~"+value+"~";
  }

}
