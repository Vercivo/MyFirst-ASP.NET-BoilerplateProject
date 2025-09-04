import { MyLearningProjectTemplatePage } from './app.po';

describe('MyLearningProject App', function () {
    let page: MyLearningProjectTemplatePage;

    beforeEach(() => {
        page = new MyLearningProjectTemplatePage();
    });

    it('should display message saying app works', () => {
        page.navigateTo();
        expect(page.getParagraphText()).toEqual('app works!');
    });
});
