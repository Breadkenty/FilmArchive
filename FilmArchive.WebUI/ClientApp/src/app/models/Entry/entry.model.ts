import { Photo } from "../Photo/photo";

export class Entry {
  id: number;
  title: string;
  date: Date;
  thumbnailUrl: string;
  photos: Photo[];
  notes: string;
}
