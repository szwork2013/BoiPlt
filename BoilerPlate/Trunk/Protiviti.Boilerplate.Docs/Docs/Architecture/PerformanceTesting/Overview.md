Performance Testing
========================

Goals of our Test:
----------------

	• Identify the capabilities of the applications
	• Explore What the app can do
	• Verify it is capable of supporting the expected users.
	• Find the limits, keep adding users and see where it crashes.
	• Crush the application to see how it crashes (the way it fails.)

Ways to run it:
----------------

	• Traditional load test use your machine to generate the many requests for the load tests but that is limited by that machine ability.
	• Load test Rig gives you more power by having load agents generate there requests and it is not limited to one machine.


General Notes:
----------------

	• Create a performance test start with recording then validation can be done with built in Validation and extraction roles that work very well out of the box, but the user have the option to create his own validation and extraction roles. 
	• Each performance test will eventually become a load test. So plan on that.
	• Make each performance test do 1 thing only, the more things each test does, the harder it will be to decide in the feature which component is responsible for the slowness.
	• Make sure the name of the test is short, if it is long, then your test probably doing too much in a single test.
	• Avoid hard-coded server addresses so you can use your test on different environments. You want to have different parameters for different environments.


<p class="updated">Updated on 10/10/2014 by Saleh Motan</p>
<p class="reviewed">Reviewed on 11/10/2014 by Saleh Motan</p>
