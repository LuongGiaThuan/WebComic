import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'chapter',
    templateUrl: './chapter.component.html',
    styleUrls: ['./chapter.component.css']
})
export class ChapterComponent {
    public chapterimgs: chapterImg[];
    public myurl = "https://hamtruyen.com/doc-truyen/tay-du-ky-ngoai-truyen-chapter-47.html";
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get('https://localhost:44340/api/thief/GetImgChapter/hamtruyen?url=' + this.myurl).subscribe(result => {
            this.chapterimgs = result.json() as chapterImg[];
        }, error => console.error(error));
    }
}
interface chapterImg {
    src: string;
}
