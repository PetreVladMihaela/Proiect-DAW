import { MarkTextPipe } from './markText.pipe';

describe('MyPipePipe', () => {
  it('create an instance', () => {
    const pipe = new MarkTextPipe();
    expect(pipe).toBeTruthy();
  });
});
