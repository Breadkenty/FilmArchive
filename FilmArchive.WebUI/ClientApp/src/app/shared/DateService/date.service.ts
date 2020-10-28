import { Injectable } from "@angular/core";
import * as moment from "moment";

@Injectable({
  providedIn: "root",
})
export class DateService {
  constructor() {}

  convertDate(date: Date, format: string) {
    return moment(date).format(format);
  }
}
