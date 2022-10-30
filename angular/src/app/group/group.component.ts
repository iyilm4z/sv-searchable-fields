import { ChangeDetectionStrategy, Component, Input } from "@angular/core";
import { GroupModel } from "src/models/group-model";

@Component({
  selector: "app-group",
  templateUrl: "./group.component.html",
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GroupComponent {
  @Input() model: GroupModel | undefined;
}
