import { BuildingModel } from "./building-model";
import { GroupModel } from "./group-model";
import { LockModel } from "./lock-model";
import { MediaModel } from "./media-model";

export interface SearchResult {
  groups: GroupModel[];
  medias: MediaModel[];
  buildings: BuildingModel[];
  locks: LockModel[];
  orderedModelIds: string[];
}
