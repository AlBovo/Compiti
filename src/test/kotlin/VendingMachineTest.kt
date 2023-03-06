import org.junit.jupiter.api.*
class VendingMachineTest{
    private fun repair(machine: VendingMachine){
        if(machine.isBroken()){
            machine.repairVendingMachine()
            machine.updateStatus(true)
        }
    }
    @Test
    fun theMachineMustBeOffAtTheStart(){
        val machine = VendingMachine(10.0, 30)
        val expected = false
        Assertions.assertEquals(expected, machine.vendingMachineIsOn())
    }
    @Test
    fun theMachineMustBeOnWhenIsSetOn(){
        val machine = VendingMachine(10.2, 30)
        val expected = true
        machine.updateStatus(true)
        repair(machine)
        Assertions.assertEquals(expected, machine.vendingMachineIsOn())
    }
    @Test
    fun theMachineCannotBeOffBeforeAddingMoney(){
        val machine = VendingMachine(12.4, 30)
        assertThrows<IllegalArgumentException> { machine.addMoney(10.0) }
    }
    @Test
    fun theMachineCanBeOnBeforeAddingMoney(){
        val machine = VendingMachine(32.2, 20)
        val expected = 10.0
        machine.updateStatus(true)
        machine.addMoney(10.0)
        repair(machine)
        Assertions.assertEquals(expected, machine.getCurrentQuantityOfMoney())
    }
    @Test
    fun theMachineCannotBeOffBeforeGettingRest(){
        val machine = VendingMachine(12.4, 30)
        machine.updateStatus(true)
        machine.addMoney(30.0)
        repair(machine)
        machine.updateStatus(false)
        assertThrows<IllegalArgumentException> { machine.getRest(10.0) }
    }
    @Test
    fun theMachineCanBeOnBeforeGettingRest(){
        val machine = VendingMachine(20.1, 30)
        val expected = 10.0
        machine.updateStatus(true)
        machine.addMoney(20.0)
        repair(machine)
        machine.getRest(10.0)
        repair(machine)
        Assertions.assertEquals(expected, machine.getCurrentQuantityOfMoney())
    }
    @Test
    fun theMachineCannotBeOffBeforeBuyingASnack(){
        val machine = VendingMachine(1.3, 30)
        machine.updateStatus(true)
        machine.addMoney(10.0)
        repair(machine)
        machine.updateStatus(false)
        repair(machine)
        assertThrows<IllegalArgumentException> { machine.buySnack(3) }
    }
    @Test
    fun theMachineCanBeOnBeforeBuyingASnack(){
        val machine = VendingMachine(2.3, 30)
        val expected = 26
        val expectedSecond = 10.0 - 2.3*4
        machine.updateStatus(true)
        machine.addMoney(10.0)
        repair(machine)
        machine.buySnack(4)
        repair(machine)
        Assertions.assertEquals(expected, machine.getSnackQuantity())
        Assertions.assertEquals(expectedSecond, machine.getCurrentQuantityOfMoney())
    }
    @Test
    fun theMachineCannotBeBrokenBeforeAddingMoney(){
        val machine = VendingMachine(3.2, 30)
        machine.updateStatus(true)
        machine.vendingMachineIsNowBroken(true)
        assertThrows<IllegalArgumentException> { machine.addMoney(10.0) }
    }
    @Test
    fun theMachineMustHaveMoneyBeforeGettingRest(){
        val machine = VendingMachine(32.1, 20)
        assertThrows<IllegalArgumentException> { machine.getRest(10.0) }
    }

}