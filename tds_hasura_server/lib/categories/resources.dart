import 'package:shelf_modular/shelf_modular.dart';

import 'api/get_all_categories.dart';

class CategoriesResource extends Resource {
  @override
  List<Route> get routes => [
        Route.get('/categories', getAllCategories),
      ];
}
