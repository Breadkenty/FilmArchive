import { HttpErrorResponse, HttpEventType } from "@angular/common/http";
import { Component, OnInit, Output } from "@angular/core";
// import { EventEmitter } from "protractor";
import { ImageService } from "src/app/shared/ImageService/image.service";

@Component({
  selector: "app-upload",
  templateUrl: "./upload.component.html",
  styleUrls: ["./upload.component.less"],
})
export class UploadComponent {
  files: File[] = [];
  imageService$;
  progress: number;
  message: string;

  constructor(private imageService: ImageService) {
    this.imageService$ = this.imageService;
  }

  onSelect(event) {
    console.log(event);
    this.files.push(...event.addedFiles);
  }

  onRemove(event) {
    console.log(event);
    this.files.splice(this.files.indexOf(event), 1);
  }

  checkFiles() {
    for (const file of this.files) {
      const formData = new FormData();
      formData.append("file", file);
      const url = this.imageService$
        .uploadImages(formData)
        .then((data) => console.log(data));
      // console.log(url);
    }
  }
}
