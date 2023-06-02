import 'package:shelf_modular/shelf_modular.dart';

import 'api/get_all_movies.dart';

class MoviesResource extends Resource {
  @override
  List<Route> get routes => [
        Route.get('/movies', getAllMovies),
      ];
}
