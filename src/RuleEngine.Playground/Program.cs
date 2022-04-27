using RuleEngine.Playground;

var service = new ExpressionService();

var expression = service.GenerateExpression();
var expressionFromPattern = service.GenerateExpressionFromPattern(expression);