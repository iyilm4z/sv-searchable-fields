import { GroupModel } from "./group-model";

export interface MediaModel {
  id: string;
  type: string;
  owner: string;
  description?: any;
  serialNumber: string;
  groupId: string;
  group: GroupModel;
  modelType: string;
  searchingWeight: number;
}
