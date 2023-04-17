// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
fun isPromoted(insufficiencyNumber: Int, debitPoints: Int): Boolean{
    require(insufficiencyNumber >= 0){
        "The number of insufficiency cannot be negative"
    }
    require(debitPoints >= 0){
        "The number of debit points cannot be negative"
    }
    require(debitPoints >= insufficiencyNumber){
        "The number of debit points must be greater or equal to the number of insufficiency"
    }
    require(debitPoints <= insufficiencyNumber * 5){
        "The number of debit points cannot be lower or equal to insufficiency times 5"
    }
    return insufficiencyNumber <= 3 && debitPoints < 5
}