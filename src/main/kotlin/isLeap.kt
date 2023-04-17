// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
fun isLeap(year: Int): Boolean{
    return if(year % 4 == 0){
        !(year % 100 == 0 && year % 400 != 0)
    }
    else{
        false
    }
}