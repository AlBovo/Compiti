import org.junit.jupiter.api.*
internal class CalculateElectricalResistanceKtTest{
    @Test
    fun cannotHaveVoltageLowerThanZero(){
        assertThrows<IllegalArgumentException> {calculateElectricalResistance(-1.0, 10.0)}
    }

    @Test
    fun cannotHaveElectricCurrentLowerOrEqualToZero(){
        assertThrows<IllegalArgumentException> {calculateElectricalResistance(10.0, 0.0)}
    }

    @Test
    fun cannotHaveBothValuesLowerThanZero(){
        assertThrows<IllegalArgumentException> {calculateElectricalResistance(-1.0, -1.0)}
    }

    @Test
    fun canHavePositiveVoltage(){
        val expected = 10.0
        Assertions.assertEquals(expected, calculateElectricalResistance(20.0, 2.0))
    }

    @Test
    fun canHavePositiveElectricCurrent(){
        val expected = 5.0
        Assertions.assertEquals(expected, calculateElectricalResistance(15.0, 3.0))
    }

    @Test
    fun canHaveBothPositiveValues(){
        val expected = 5.0
        Assertions.assertEquals(expected, calculateElectricalResistance(10.0, 2.0))
    }
}