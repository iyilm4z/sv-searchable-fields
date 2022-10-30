import { ChangeDetectionStrategy, Component, Input } from "@angular/core";
import { LockModel } from "src/models/lock-model";

@Component({
  selector: "app-lock",
  templateUrl: "./lock.component.html",
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LockComponent {
  @Input() model: LockModel | undefined;
}
