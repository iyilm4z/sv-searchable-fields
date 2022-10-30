import { BuildingModel } from "./building-model";

export interface LockModel {
  id: string;
  type: string;
  name: string;
  serialNumber: string;
  floor: string;
  roomNumber: string;
  description?: any;
  buildingId: string;
  building: BuildingModel;
  modelType: string;
  searchingWeight: number;
}
