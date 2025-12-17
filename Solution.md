Flow

1. initial setup get it to work, I have 2 sdks
2. Resturecture the project to have separated concersn into a service layer only for now. (Clean architecture)
3. Resolve erros and replace the react simulated api with the actual backend endpoint
4. Once it works create the basic test to mock the existing mocking structure in the calculate commision method.
5. Use a real input in test case and modify the service method to fix it.
6. Start edge cases for request val;idation. Do not add client side validation(assuming)
7. Created a separate Validator service that is more modular and can be extended or replaced in the future.
8. Add fluent validation from the start even though it's simple?

Todo:

issue with runnign jest tests not important as react doesn't drive tdd in this case
