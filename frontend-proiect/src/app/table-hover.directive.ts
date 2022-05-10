import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appTableHover]'
})
export class TableHoverDirective {

  constructor(
    public el: ElementRef
  ) { }

  @HostListener('mouseenter') onMouseEnter() {
    this.highlight('dodgerblue');
  }

  @HostListener('mouseleave') onMouseLeave() {
    this.highlight('');
  }

  @HostListener('click') onClick() {
    this.el.nativeElement.style.color = 'springgreen';
  }

  private highlight(color: string) {
    this.el.nativeElement.style.backgroundColor = color;
  }

}
