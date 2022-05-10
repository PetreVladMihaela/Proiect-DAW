import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appButtonHover]'
})
export class ButtonHoverDirective {

  constructor(
    public el: ElementRef
  ) { }

  @HostListener('mouseenter') onMouseEnter() {
    this.highlight('deepskyblue');
  }

  @HostListener('mouseleave') onMouseLeave() {
    this.highlight('');
  }

  private highlight(color: string) {
    this.el.nativeElement.style.backgroundColor = color;
  }

}