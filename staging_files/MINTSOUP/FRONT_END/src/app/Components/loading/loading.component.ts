import { Component, OnInit, Input } from '@angular/core';
import { LoadingSpinnerService } from 'src/app/Services/loading-spinner.service';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.css']
})
export class LoadingComponent implements OnInit {
  @Input() public message?: string;
  constructor(public loading: LoadingSpinnerService) { }

  ngOnInit(): void {
  }
  showSpinner(){
    this.loading.show()
    
  }

}
