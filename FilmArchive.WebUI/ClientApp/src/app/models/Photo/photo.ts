import { Camera } from "../Camera/camera";
import { Film } from "../Film/film";

export class Photo {
  id: number;
  url: string;
  camera: Camera;
  film: Film;
  exposureIndex: number;
  location: string;
  city: string;
  state: string;
  country: string;
}
