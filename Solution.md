Flow

1. initial setup get it to work, I have 2 sdks
2. Resturecture the project to have separated concersn into a service layer only for now. (Clean architecture)
3. Resolve erros and replace the react simulated api with the actual backend endpoint
4. Once it works create the basic test to mock the existing mocking structure in the calculate commision method.
5. Use a real input in test case and modify the service method to fix it.
6. Start edge cases for request val;idation. Do not add client side validation(assuming)
7. options - 1. a separate Validator service that is more modular and can be extended or replaced in the future.2. fluent validation
8. Add fluent validation from the start even though it's simple. Let's it scale no tighly coupled vlidator service
9. Added a fixed error response type : simple for now jsut the message but later can be coupled with globalexception middleware and include the stacktrace in dev mode

Todo:

Added someking of graceful error handling
simple solution -> add a exception middle where and fixed error results as the application scales

I need to display the error message on the frontend

DTOs are fairly compact -> include the breakdown and refator the ui in future

issue with running jest tests not important as react doesn't drive tdd in this case

Error response
