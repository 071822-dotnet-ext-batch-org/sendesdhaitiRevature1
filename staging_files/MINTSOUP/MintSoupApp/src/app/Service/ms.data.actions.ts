import { timer } from 'rxjs';

export class mintsoupTimerClass{
    constructor(){
        this.msTime = 500;//half a second or 500 milli-seconds
        this.msTimeLeft = 600000;//1 hour or 600,000 milli-seconds
    }
    public msTime:number;
    public msTimeLeft:number;
    
    
    msTimer(durationTime_in_millisec:number) :void{
        const source = timer(this.msTime, durationTime_in_millisec);
        const abc = source.subscribe((val:number) => {
            console.log(val, '-');
            this.msTime = this.msTimeLeft - val;
        });
    }
}