fun checkTypeOfTriangle(segmentFirst: Double, segmentSecond: Double, segmentThird: Double): Int{
    require(segmentFirst > 0 && segmentSecond > 0 && segmentThird > 0){
        "A segment cannot have negative length"
    }
    return if(segmentFirst == segmentSecond && segmentSecond == segmentThird) {
        1
    } else if(segmentFirst != segmentSecond && segmentSecond != segmentThird && segmentFirst != segmentThird){
        2
    } else {
        3
    }
}