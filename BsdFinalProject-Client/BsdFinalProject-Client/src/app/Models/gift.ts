import { CardModel } from "./card";

export class GiftModel {
  id!: number;
  name!: string;
  description?: string;
  cost!: number;
  picture?: string;
  categoryId!: number;
  donorId!: number;
  winnerName?: string;
  donorName?: string; 
  tickets?: CardModel[];
}