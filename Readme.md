# AHOYTEL.API Solution

This was done for a Backend Interview Assesment for AHOY.

The minimum required features/APIs to support
One API for listing/searching for a hotel
API for viewing details and info about a specific hotel
API for placing a booking

It is well architected with multile Tasks for booking as well as search multiple or find a specific hotel.

# AHOYTEL.API 
	Has 
		BookingController ccalls the BookingProcessor
		SearchController calls the SearchProcessor

# AHOYTel.LIB.Application
	Has
		ApiWorkflowManager which manages the tasks required to run these processors

#AHOYTel.Repository.DB 
	DB layer was incomplete as need to do the Domain Model to View model and viceversa binding

