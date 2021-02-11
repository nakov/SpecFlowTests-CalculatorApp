Feature: Metric Calculator
	Users can convert between metrics using the Calculator Web app:
	https://js-calculator.nakov.repl.co, from the [Metric Calculator] tab
	(e.g. conver 5.3 meters to centimeters).

Scenario: Convert meters to centimeters
	Given the input value is 5.2
	And the source metric is "m"
	And the destination metric is "cm"
	When the conversion is performed
	Then the result should be 520

Scenario: Convert meters to milimeters
	Given the input value is 5.3
	And the source metric is "m"
	And the destination metric is "mm"
	When the conversion is performed
	Then the result should be 5300

Scenario: Convert meters to kilometers
	Given the input value is 5.4
	And the source metric is "m"
	And the destination metric is "km"
	When the conversion is performed
	Then the result should be 0.0054

Scenario: Convert centimeters to milimeter
	Given the input value is 5.5
	And the source metric is "cm"
	And the destination metric is "mm"
	When the conversion is performed
	Then the result should be 55

Scenario: Convert centimeters to meters
	Given the input value is 5.6
	And the source metric is "cm"
	And the destination metric is "m"
	When the conversion is performed
	Then the result should be 0.056

Scenario: Convert centimemeters to kilometers
	Given the input value is 5.7
	And the source metric is "cm"
	And the destination metric is "km"
	When the conversion is performed
	Then the result should be 0.000057
