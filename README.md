# SaveGameDataUsingRESTAPI
HOW TO USE

1. Install xampp.
2. Run local Apache and MySQL server.
3. Download provided sql file and import database into localhost/phpmyadmin.
4. Download provided rest-api.
5. Place folder into xampp/htdocs directory.
6. Run unity project!
7. Done.

This includes REST-API made in php, simple database and unity project.

This project was made for a school assignment, the project is a simple game where you move a character to the cursors position when clicked. Clicking on a flying ball will grant you 1 point. Pressing the save button will send a post request to the api with the relevant json data and store it in the database. When starting the game the user will recieve an option to sign in/register. Once signed in the previous score data will be loaded from the database through the api. The login/signup process is also handeled through the api.

I chose to use a rest-api to challange myself instead of saving data through playerprefs in unity.
